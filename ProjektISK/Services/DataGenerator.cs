using System.Collections.Generic;
using System.Linq;
using System.Text;
using ProjektISK.Enums;
using ProjektISK.Infrastructure;
using ProjektISK.Interfaces;
using ProjektISK.Models;

namespace ProjektISK.Services
{
    public static class DataGenerator
    {
        public static string GenerateBytes(int length)
        {
            var builder = new StringBuilder(length);

            for (int i = 0; i < length; i++)
                builder.Append("10101010");

            return builder.ToString();
        }

        public static Frame GenerateFrame(int length, ChecksumType checksumType, int checksumLength)
        {
            string data = GenerateBytes(length);

            IChecksumCalculator calculator = ChecksumCalculatorFactory.Create(checksumType);
            string checksum = calculator.Calculate(data, checksumLength);
            
            return new Frame(data, checksum);
        }

        public static Packet GeneratePacket(List<Frame> frames, ChecksumType checksumType, int checksumLength)
        {
            IChecksumCalculator calculator = ChecksumCalculatorFactory.Create(checksumType);
            string framesData = string.Join("", frames.Select(f => f.GetFrame()));
            string checksum = calculator.Calculate(framesData, checksumLength);

            return new Packet(frames, checksum);
        }
    }
}
