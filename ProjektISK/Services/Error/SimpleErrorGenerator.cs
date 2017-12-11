using System;
using System.Linq;
using System.Text;
using ProjektISK.Interfaces;

namespace ProjektISK.Services.Error
{
    public class SimpleErrorGenerator : IErrorGenerator
    {
        public string MakeErrors(string data)
        {
            StringBuilder errorBuilder = new StringBuilder(data.Length);

            int errorsToMake = new Random().Next(1, data.Length - 1);
            int startFrom = new Random().Next(0, data.Length - errorsToMake);
            int errorBitsCount = 0;

            errorBuilder.Append(data.Substring(0, startFrom));
            for (int i = startFrom; i < data.Length; i++)
            {
                string bit = data.Substring(i, 1);
                if (errorBitsCount < errorsToMake)
                {
                    errorBuilder.Append(Swap(bit));
                    errorBitsCount++;
                }
                else
                {
                    errorBuilder.Append(bit);
                }
            }

            return errorBuilder.ToString();
        }

        private string Swap(string toSwap)
        {
            return toSwap == "0" ? "1" : "0";
        }
    }
}
