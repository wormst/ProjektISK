using System;
using System.Linq;
using System.Text;
using ProjektISK.Interfaces;

namespace ProjektISK.Services.Checksum
{
    public class CrcCalculator : IChecksumCalculator
    {
        public string Calculate(string data, int length)
        {
            string polynomial = GetPolynomial(length);
            var crcZeros = string.Join("", Enumerable.Repeat('0', length).ToArray());
            char[] shift = (data + crcZeros).ToCharArray();

            while (shift.Length > length)
            {
                if (shift[0] == '1')
                {
                    for (int i = 0; i < length; i++)
                    {
                        if (shift[i + 1] == polynomial[i])
                            shift[i + 1] = '0';
                        else
                            shift[i + 1] = '1';
                    }
                }

                shift = shift.Skip(1).ToArray();
            }

            string checksum = string.Join("", shift);
            return checksum;
        }

        private string GetPolynomial(int length)
        {
            string polynomial = "0100001011110000111000011110101110101001111010100011011010010011"; //"0x42F0E1EBA9EA3693"
            string substring = polynomial.Substring(polynomial.Length - length, length);
            return substring;
        }
    }
}
