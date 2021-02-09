using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace LichenOrganizer.UI.ViewModels
{
    public class ViewModelBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        //We want to allow subclasses to use this method, so we make it protected.  We also want them to be able to override it, 
        //so we make it virtual as well. 
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
 