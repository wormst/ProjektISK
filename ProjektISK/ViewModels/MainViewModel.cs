using System.Collections.Generic;
using ProjektISK.Infrastructure;
using ProjektISK.Models;
using ProjektISK.Services;
using ProjektISK.ViewModels.Base;

namespace ProjektISK.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        public MainViewModel()
        {
            StartCommand = new SimpleCommand(obj => IsValid, Start);
        }

        public ChecksumViewModel FrameChecksumViewModel { get; } = new ChecksumViewModel();
        public ChecksumViewModel PacketChecksumViewModel { get; } = new ChecksumViewModel();

        public SizeViewModel FrameSizeViewModel { get; } = new SizeViewModel();
        public SizeViewModel PacketSizeViewModel { get; } = new SizeViewModel();

        public ErrorsViewModel ErrorsViewModel { get; } = new ErrorsViewModel();
        public SizeViewModel ErrorsSizeViewModel { get; } = new SizeViewModel();

        public DurationViewModel DurationViewModel { get; } = new DurationViewModel();

        public SimpleCommand StartCommand { get; }

        public override bool IsValid => FrameChecksumViewModel.IsValid && PacketChecksumViewModel.IsValid &&
                                        FrameSizeViewModel.IsValid && PacketSizeViewModel.IsValid &&
                                        DurationViewModel.IsValid && ErrorsViewModel.IsValid && ErrorsSizeViewModel.IsValid;

        private void Start(object parameter)
        {
            List<Frame> frames = new List<Frame>();
            for (int i = 0; i < PacketSizeViewModel.GetSize(); i++)
            {
                frames.Add(DataGenerator.GenerateFrame(FrameSizeViewModel.GetSize(),
                    FrameChecksumViewModel.SelectedChecksumType, FrameChecksumViewModel.GetChecksumSize()));
            }

            Packet packet = DataGenerator.GeneratePacket(frames, 
                PacketChecksumViewModel.SelectedChecksumType, PacketChecksumViewModel.GetChecksumSize());

            ErrorNumbers errorNumbers = new ErrorNumbers
            {
                SizeType = ErrorsSizeViewModel.SizeType,
                FixedSize = ErrorsSizeViewModel.FixedSize,
                RandomEnd = ErrorsSizeViewModel.RandomEnd,
                RandomStart = ErrorsSizeViewModel.RandomStart
            };

            SimulatorOptions options = new SimulatorOptions
            {
                Packet = packet,
                DurationModel = DurationViewModel,
                ErrorGenerator = ErrorGeneratorFactory.Create(ErrorsViewModel.ErrorPositionType, errorNumbers),
                FrameChecksumType = FrameChecksumViewModel.SelectedChecksumType,
                PacketChecksumType = PacketChecksumViewModel.SelectedChecksumType
            };

            Simulator simulator = new Simulator(options);
            SimulatorWindow simulatorWindow = new SimulatorWindow(simulator);
            simulatorWindow.ShowDialog();
        }
    }
}
