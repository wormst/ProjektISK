using System;
using ProjektISK.Enums;
using ProjektISK.Interfaces;
using ProjektISK.Models;
using ProjektISK.Services.Error;

namespace ProjektISK.Infrastructure
{
    public static class ErrorGeneratorFactory
    {
        public static IErrorGenerator Create(ErrorPositionType positionType, ErrorNumbers errorNumbers)
        {
            switch (positionType)
            {
                case ErrorPositionType.Random:
                    return new RandomErrorGenerator(errorNumbers);
                case ErrorPositionType.Neighbours:
                    return new SimpleErrorGenerator(errorNumbers);
            }

            throw new NotSupportedException($"Error Generator of type {positionType} is not supported yet.");
        }
    }
}