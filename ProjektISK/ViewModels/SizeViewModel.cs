using System;
using System.ComponentModel;
using ProjektISK.Enums;
using ProjektISK.ViewModels.Base;

namespace ProjektISK.ViewModels
{
    public class SizeViewModel : ViewModelBase, IDataErrorInfo
    {
        private SizeType _sizeType;
        private int _fixedSize = 5;
        private int _randomStart = 0;
        private int _randomEnd = 5;

        public SizeType SizeType
        {
            get => _sizeType;
            set { _sizeType = value; OnPropertyChanged(); }
        }

        public int FixedSize
        {
            get => _fixedSize;
            set { _fixedSize = value; OnPropertyChanged();}
        }

        public int RandomStart
        {
            get => _randomStart;
            set { _randomStart = value; OnPropertyChanged(); }
        }

        public int RandomEnd
        {
            get => _randomEnd;
            set { _randomEnd = value; OnPropertyChanged();}
        }

        public int GetSize()
        {
            if (SizeType == SizeType.RandomSize)
                return new Random().Next(RandomStart, RandomEnd + 1);

            return FixedSize;
        }

        public string this[string columnName]
        {
            get
            {
                if (columnName == nameof(FixedSize))
                {
                    if (FixedSize <= 0)
                    {
                        IsValid = false;
                        return "Niepoprawna wartość!";
                    }
                }
                else if (columnName == nameof(RandomStart) || columnName == nameof(RandomEnd))
                {
                    if (RandomStart >= RandomEnd || RandomStart < 0)
                    {
                        IsValid = false;
                        return "Niepoprawna wartość!";
                    }
                }

                IsValid = true;
                return string.Empty;
            }
        }

        public string Error { get; }
    }
}
