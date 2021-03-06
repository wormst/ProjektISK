﻿using System;
using System.Text;
using ProjektISK.Enums;
using ProjektISK.Interfaces;
using ProjektISK.Models;

namespace ProjektISK.Services.Error
{
    public class SimpleErrorGenerator : IErrorGenerator
    {
        private readonly ErrorNumbers _errors;

        public SimpleErrorGenerator(ErrorNumbers errors)
        {
            _errors = errors;
        }

        public string MakeErrors(string data)
        {
            StringBuilder errorBuilder = new StringBuilder(data.Length);

            int errorsToMake = GetNumberOfErrors(data);
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
