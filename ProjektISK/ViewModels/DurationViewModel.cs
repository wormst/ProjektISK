using System.ComponentModel;
using ProjektISK.Enums;
using ProjektISK.ViewModels.Base;

namespace ProjektISK.ViewModels
{
    public class DurationViewModel : ViewModelBase, IDataErrorInfo
    {
        private DurationType _durationType;
        private int _count = 10000;
        private int _uptime = 30;

        public DurationType DurationType
        {
            get => _durationType;
            set { _durationType = value; OnPropertyChanged(); }
        }

        public int Count
        {
            get => _count;
            set { _count = value; OnPropertyChanged(); }
        }

        public int Uptime
        {
            get => _uptime;
            set { _uptime = value; OnPropertyChanged(); }
        }

        public string this[string columnName]
        {
            get
            {
                if (columnName == nameof(Count))
                {
                    if (Count <= 0)
                    {
                        IsValid = false;
                        return "Niepoprawna wartość!";
                    }
                }
                else if (columnName == nameof(Uptime) )
                {
                    if (Uptime <= 0)
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
