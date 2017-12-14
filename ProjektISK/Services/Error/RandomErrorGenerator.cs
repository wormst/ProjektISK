using System;
using System.Collections.Generic;
using System.Text;
using ProjektISK.Enums;
using ProjektISK.Interfaces;
using ProjektISK.Models;

namespace ProjektISK.Services.Error
{
    public class RandomErrorGenerator : IErrorGenerator
    {
        private readonly ErrorNumbers _errors;

        public RandomErrorGenerator(ErrorNumbers errors)
        {
            _errors = errors;
        }

        public string MakeErrors(string data)
        {
            StringBuilder errorBuilder = new StringBuilder(data.Length);

            int errorsToMake = GetNumberOfErrors(data);

            Random random = new Random();
            HashSet<int> indexesToMakeErrorOn = new HashSet<int>();
            while (indexesToMakeErrorOn.Count < errorsToMake && indexesToMakeErrorOn.Count <= data.Length - 2)
            {
                int index = random.Next(0, data.Length - 1);
                if (!indexesToMakeErrorOn.Contains(index))
                {
                    indexesToMakeErrorOn.Add(index);
                }
            }

            for (int i = 0; i < data.Length; i++)
            {
                string bit = data.Substring(i, 1);
                errorBuilder.Append(indexesToMakeErrorOn.Contains(i) ? Swap(bit) : bit);
            }

            return errorBuilder.ToString();
        }

        private int GetNumberOfErrors(string data)
        {
            int errorsToMake = 0;
            if (_errors.SizeType == SizeType.FixedSize)
            {
                errorsToMake = _errors.FixedSize;
            }
            else if (_errors.SizeType == SizeType.RandomSize)
            {
                errorsToMake = new Random().Next(_errors.RandomStart,
                    _errors.RandomEnd >= data.Length ? data.Length - 1 : _errors.RandomEnd);
            }

            return errorsToMake;
        }

        private string Swap(string toSwap)
        {
            return toSwap == "0" ? "1" : "0";
        }
    }
}
