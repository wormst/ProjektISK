using System.ComponentModel;
using ProjektISK.Enums;
using ProjektISK.ViewModels.Base;

namespace ProjektISK.ViewModels
{
    public class ErrorsViewModel : ViewModelBase, IDataErrorInfo
    {
        private ErrorPositionType _errorPositionType;
        private ErrorAreaType _errorAreaType;
        private int _frameNumber = 3;

        public ErrorPositionType ErrorPositionType
        {
            get => _errorPositionType;
            set { _errorPositionType = value; OnPropertyChanged();}
        }

        public ErrorAreaType ErrorAreaType
        {
            get => _errorAreaType;
            set { _errorAreaType = value; OnPropertyChanged(); }
        }

        public int FrameNumber
        {
            get => _frameNumber;
            set { _frameNumber = value; OnPropertyChanged();}
        }

        public string this[string columnName]
        {
            get
            {
                if (columnName == nameof(FrameNumber))
                {
                    if (FrameNumber <= 0)
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
