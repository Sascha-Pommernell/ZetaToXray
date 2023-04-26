using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace MVVM_Base
{
    public abstract class ViewModelBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public void RaisePropertyChange([CallerMemberName] string propertyName = "")
        {
           if(!string.IsNullOrEmpty(propertyName))
                this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
