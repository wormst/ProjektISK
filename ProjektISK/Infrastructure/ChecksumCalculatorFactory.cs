using System;
using ProjektISK.Enums;
using ProjektISK.Interfaces;
using ProjektISK.Services.Checksum;

namespace ProjektISK.Infrastructure
{
    public static class ChecksumCalculatorFactory
    {
        public static IChecksumCalculator Create(ChecksumType checksumType)
        {
            if (checksumType == ChecksumType.ParityBit)
                return new ParityBitCalculator();
            if (checksumType == ChecksumType.SumOfBytes)
                return new ByteSumCalculator();
            if (checksumType == ChecksumType.Crc)
                return new CrcCalculator();

            throw new NotSupportedException($"Checksum of type {checksumType} is not supported yet.");
        }
    }
}
