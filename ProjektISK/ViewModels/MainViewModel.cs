using System.Collections.Generic;
using ProjektISK.Models;
using ProjektISK.Services;
using ProjektISK.Services.Error;
using ProjektISK.ViewModels.Base;

namespace ProjektISK.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        public MainViewModel()
        {
            StartCommand = new SimpleCommand(Start);
        }

        public ChecksumViewModel FrameChecksumViewModel { get; } = new ChecksumViewModel();
        public ChecksumViewModel PacketChecksumViewModel { get; } = new ChecksumViewModel();
        public SizeViewModel FrameSizeViewModel { get; } = new SizeViewModel();
        public SizeViewModel PacketSizeViewModel { get; } = new SizeViewModel();
        public DurationViewModel DurationViewModel { get; } = new DurationViewModel();
        public SimpleCommand StartCommand { get; }

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

            SimulatorOptions options = new SimulatorOptions
            {
                Packet = packet,
                DurationModel = DurationViewModel,
                ErrorGenerator = new SimpleErrorGenerator(),
                FrameChecksumType = FrameChecksumViewModel.SelectedChecksumType,
                PacketChecksumType = PacketChecksumViewModel.SelectedChecksumType
            };

            Simulator simulator = new Simulator(options);
            SimulatorWindow simulatorWindow = new SimulatorWindow(simulator);
            simulatorWindow.ShowDialog();
        }
    }
}
