using ProjektISK.Enums;
using ProjektISK.ViewModels.Base;

namespace ProjektISK.ViewModels
{
    public class DurationViewModel : ViewModelBase
    {
        private DurationType _durationType;
        private int _count;
        private int _uptime;

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
    }
}
