using System.Linq;
using ProjektISK.Interfaces;

namespace ProjektISK.Services.Checksum
{
    public class ParityBitCalculator : IChecksumCalculator
    {
        public string Calculate(string data, int length)
        {
            int count = data.Count(d => d == '1');
            int parityBit = (count % 2 == 0) ? 0x00 : 0x01;

            return (parityBit & 0x01).ToString();
        }
    }
}
