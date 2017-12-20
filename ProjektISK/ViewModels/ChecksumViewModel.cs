using System;
using System.ComponentModel;
using ProjektISK.Enums;
using ProjektISK.ViewModels.Base;

namespace ProjektISK.ViewModels
{
    public class ChecksumViewModel : ViewModelBase, IDataErrorInfo
    {
        private ChecksumType _selectedChecksumType;
        private int _checksumSize = 8;

        public ChecksumType SelectedChecksumType
        {
            get => _selectedChecksumType;
            set { _selectedChecksumType = value; OnPropertyChanged(null); } 
        }

        public int ChecksumSize
        {
            get => _checksumSize;
            set { _checksumSize = value; OnPropertyChanged(null); }
        }

        public string this[string columnName]
        {
            get
            {
                if (columnName == nameof(ChecksumSize))
                {
                    if (ChecksumSize > 64 || ChecksumSize <= 0)
                    {
                        IsValid = false;
                        return "Niepoprawna suma kontrolna!";
                    }
                }

                IsValid = true;
                return string.Empty;
            }
        }

        public string Error { get; }

        public int GetChecksumSize()
        {
            if (_selectedChecksumType == ChecksumType.ParityBit)
                return 1;

            return ChecksumSize;
        }
    }
}
