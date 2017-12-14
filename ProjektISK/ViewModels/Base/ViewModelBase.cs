using System.ComponentModel;
using System.Runtime.CompilerServices;
using ProjektISK.Properties;

namespace ProjektISK.ViewModels.Base
{
    public class ViewModelBase : INotifyPropertyChanged
    {
        private bool _isValid = true;
        public event PropertyChangedEventHandler PropertyChanged;

        public virtual bool IsValid
        {
            get => _isValid;
            set { _isValid = value; OnPropertyChanged(); }
        }

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
