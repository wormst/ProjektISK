using ProjektISK.Enums;
using ProjektISK.ViewModels.Base;

namespace ProjektISK.ViewModels
{
    public class SimulatorResult : ViewModelBase
    {
        public int Processed
        {
            get => _processed;
            set { _processed = value; OnPropertyChanged(); }
        }
        public int WrongAsWrong
        {
            get => _wrongAsWrong;
            set { _wrongAsWrong = value; OnPropertyChanged(); }
        }
        public int WrongAsProper
        {
            get => _wrongAsProper;
            set { _wrongAsProper = value; OnPropertyChanged(); }
        }
        public int ProperAsProper
        {
            get => _properAsProper;
            set { _properAsProper = value; OnPropertyChanged(); }
        }
        public int ProperAsWrong
        {
            get => _properAsWrong;
            set { _properAsWrong = value; OnPropertyChanged(); }
        }

        public void AddResult(ChecksumResult result)
        {
            Processed++;

            switch (result)
            {
                case ChecksumResult.ProperAsProper:
                    ProperAsProper++;
                    break;
                case ChecksumResult.ProperAsWrong:
                    ProperAsWrong++;
                    break;
                case ChecksumResult.WrongAsWrong:
                    WrongAsWrong++;
                    break;
                case ChecksumResult.WrongAsProper:
                    WrongAsProper++;
                    break;
            }
        }

        private int _processed;
        private int _wrongAsWrong;
        private int _wrongAsProper;
        private int _properAsProper;
        private int _properAsWrong;
    }
}
