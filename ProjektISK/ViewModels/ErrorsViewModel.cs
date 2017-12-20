using System.ComponentModel;
using ProjektISK.Enums;
using ProjektISK.ViewModels.Base;

namespace ProjektISK.ViewModels
{
    public class ErrorsViewModel : ViewModelBase, IDataErrorInfo
    {
        private ErrorPositionType _errorPositionType;
        private int _frameNumber = 3;
        private bool _limitFaultyFrames;

        public ErrorPositionType ErrorPositionType
        {
            get => _errorPositionType;
            set { _errorPositionType = value; OnPropertyChanged();}
        }

        public bool LimitFaultyFrames
        {
            get => _limitFaultyFrames;
            set { _limitFaultyFrames = value; OnPropertyChanged(); }
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
