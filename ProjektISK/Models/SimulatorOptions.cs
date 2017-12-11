using ProjektISK.Enums;
using ProjektISK.Services.Error;
using ProjektISK.ViewModels;

namespace ProjektISK.Models
{
    public class SimulatorOptions
    {
        public Packet Packet { get; internal set; }
        public DurationViewModel DurationModel { get; set; }
        public SimpleErrorGenerator ErrorGenerator { get; set; }
        public ChecksumType FrameChecksumType { get; set; }
        public ChecksumType PacketChecksumType { get; set; }
    }
}
