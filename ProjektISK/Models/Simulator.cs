using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using ProjektISK.Enums;
using ProjektISK.Infrastructure;
using ProjektISK.ViewModels;
using ProjektISK.ViewModels.Base;

namespace ProjektISK.Models
{
    public class Simulator : ViewModelBase
    {
        private readonly SimulatorOptions _options;
        private bool _isWorking;

        public Simulator(SimulatorOptions options)
        {
            _options = options;
            StopCommand = new SimpleCommand(Stop);
        }

        public SimulatorResult FramesResults { get; } = new SimulatorResult();
        public SimulatorResult PacketsResults { get; } = new SimulatorResult();
        public SimpleCommand StopCommand { get; }
        public bool IsWorking
        {
            get => _isWorking;
            set { _isWorking = value; OnPropertyChanged();}
        }

        public void Simulate()
        {
            var simulationType = _options.DurationModel.DurationType;

            if (simulationType == DurationType.Number)
            {
                for (int packetsCount = 0; packetsCount < _options.DurationModel.Count; packetsCount++)
                {
                    ProcessOnePacket();
                }
            }

            if (simulationType == DurationType.Time)
            {
                Stopwatch timer = Stopwatch.StartNew();
                long milisecondsToElapse = _options.DurationModel.Uptime * 1000; //uptime is in seconds

                while (timer.ElapsedMilliseconds <= milisecondsToElapse)
                {
                    ProcessOnePacket();
                }

                timer.Stop();
                IsWorking = false;
                Debug.WriteLine($"Processed {PacketsResults.Processed} packets in {timer.ElapsedMilliseconds} ms.");
            }

            if (simulationType == DurationType.NoLimit)
            {
                IsWorking = true;
                while (IsWorking)
                {
                    ProcessOnePacket();
                }
            }
        }

        private void ProcessOnePacket()
        {
            Packet clonedPacket = _options.Packet.DeepClone();
            string data = clonedPacket.GetBytes();
            string dataWithError = GetDataWithError(clonedPacket, data);

            string framesOnlyData =
                dataWithError.Substring(0, dataWithError.Length - _options.Packet.Checksum.Length);

            foreach (ChecksumResult result in CheckFrames(framesOnlyData))
            {
                FramesResults.AddResult(result);
            }

            PacketsResults.AddResult(CheckPacket(dataWithError));
        }

        private string GetDataWithError(Packet clonedPacket, string data)
        {
            string dataWithError;
            if (_options.FaultyFramesNumber == 0) //make error on whole packet
            {
                dataWithError = _options.ErrorGenerator.MakeErrors(data);
            }
            else
            {
                StringBuilder dataWithErrorBuilder = new StringBuilder();

                if (_options.FaultyFramesNumber > clonedPacket.Frames.Count)
                    _options.FaultyFramesNumber = clonedPacket.Frames.Count;

                Random random = new Random();
                HashSet<Frame> frameToMakeErrorOn = new HashSet<Frame>();
                while (frameToMakeErrorOn.Count < _options.FaultyFramesNumber)
                {
                    Frame frame = clonedPacket.Frames[random.Next(0, clonedPacket.Frames.Count - 1)];
                    if (!frameToMakeErrorOn.Contains(frame))
                    {
                        frameToMakeErrorOn.Add(frame);
                    }
                }

                foreach (Frame frame in clonedPacket.Frames)
                {
                    dataWithErrorBuilder.Append(frameToMakeErrorOn.Contains(frame)
                        ? _options.ErrorGenerator.MakeErrors(frame.GetFrame())
                        : frame.GetFrame());
                }

                dataWithError = dataWithErrorBuilder.ToString();
            }

            return dataWithError;
        }

        private List<ChecksumResult> CheckFrames(string dataWithError)
        {
            List<ChecksumResult> results = new List<ChecksumResult>();

            //TODO: this could be done once
            Frame exampleFrame = _options.Packet.Frames.First();
            int frameLength = exampleFrame.GetFrame().Length;
            int frameChecksumLength = exampleFrame.Checksum.Length;
            int frameDataLength = frameLength - frameChecksumLength;

            for (int i = 0; i < dataWithError.Length / frameLength; i++)
            {
                //TODO: extract retrieving this data
                string data = dataWithError.Substring(i * frameLength, frameDataLength);
                string checksumFromData = dataWithError.Substring(i * frameLength + data.Length, frameChecksumLength);
                string recalculatedChecksum = ChecksumCalculatorFactory.Create(_options.FrameChecksumType)
                                                        .Calculate(data, frameChecksumLength);
                
                bool isDataEqual = data == _options.Packet.Frames[i].Data;
                bool isChecksumEqual = recalculatedChecksum == checksumFromData;

                results.Add(ComputeChecksumResult(isDataEqual, isChecksumEqual));
            }

            return results;
        }

        private ChecksumResult CheckPacket(string dataWithError)
        {
            //TODO: extract retrieving this data
            string dataWithoutChecksum =
                dataWithError.Substring(0, dataWithError.Length - _options.Packet.Checksum.Length);
            string receivedChecksum = dataWithError.Substring(dataWithError.Length - _options.Packet.Checksum.Length);
            string calculatedChecksum = ChecksumCalculatorFactory.Create(_options.PacketChecksumType)
                .Calculate(dataWithoutChecksum, _options.Packet.Checksum.Length);

            bool isDataEqual = dataWithoutChecksum == _options.Packet.GetBytes();
            bool isChecksumEqual = calculatedChecksum == receivedChecksum;

            return ComputeChecksumResult(isDataEqual, isChecksumEqual);
        }

        private ChecksumResult ComputeChecksumResult(bool isDataEqual, bool isChecksumEqual)
        {
            if (isDataEqual)
                return isChecksumEqual ? ChecksumResult.ProperAsProper : ChecksumResult.ProperAsWrong;
            else
                return isChecksumEqual ? ChecksumResult.WrongAsProper : ChecksumResult.WrongAsWrong;
        }

        private void Stop(object parameter)
        {
            IsWorking = false;
        }
    }
}
