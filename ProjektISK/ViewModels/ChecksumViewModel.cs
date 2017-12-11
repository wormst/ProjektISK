using System;
using ProjektISK.Enums;
using ProjektISK.ViewModels.Base;

namespace ProjektISK.ViewModels
{
    public class ChecksumViewModel : ViewModelBase
    {
        private ChecksumType _selectedChecksumType;
        private string _checksumSize;

        public ChecksumType SelectedChecksumType
        {
            get => _selectedChecksumType;
            set { _selectedChecksumType = value; OnPropertyChanged(); } 
        }

        public string ChecksumSize
        {
            get => _checksumSize;
            set { _checksumSize = value; OnPropertyChanged(); }
        }

        public int GetChecksumSize()
        {
            if (_selectedChecksumType == ChecksumType.ParityBit)
                return 1;

            return Convert.ToInt32(ChecksumSize);
        }
    }
}
