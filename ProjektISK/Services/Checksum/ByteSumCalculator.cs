using System;
using System.Linq;
using System.Text;
using ProjektISK.Interfaces;

namespace ProjektISK.Services.Checksum
{
    public class ByteSumCalculator : IChecksumCalculator
    {
        public string Calculate(string data, int length)
        {
            long sumOfBytes = 0;
            int numOfBytes = data.Length / 8;
            byte[] bytes = new byte[numOfBytes];
            for (int i = 0; i < numOfBytes; i++)
            {
                bytes[i] = Convert.ToByte(string.Join("", data.Take(8)), 2);
                data = data.Remove(0, 8);
            }

            for (int i = 0; i < bytes.Length; i++)
            {
                sumOfBytes += bytes[i];
            }

            string checksum = Convert.ToString(sumOfBytes, 2);

            if (checksum.Length < length)
            {
                string correctLengthChecksum = string.Join("", Enumerable.Repeat('0', length).ToArray());
                checksum = correctLengthChecksum.Substring(0, correctLengthChecksum.Length - checksum.Length) +
                             checksum;
            }

            return checksum.Substring(checksum.Length - length, length);
        }
    }
}
