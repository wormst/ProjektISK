using System;
using ProjektISK.Enums;
using ProjektISK.ViewModels.Base;

namespace ProjektISK.ViewModels
{
    public class SizeViewModel : ViewModelBase
    {
        private SizeType _sizeType;
        private int _fixedSize;
        private int _randomStart;
        private int _randomEnd;

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
                return new Random().Next(RandomStart, RandomEnd);

            return FixedSize;
        }
    }
}
