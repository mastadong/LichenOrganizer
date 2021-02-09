using LichenOrganizer.Model;
using LichenOrganizer.UI.Data;
using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace LichenOrganizer.UI.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        public INavigationViewModel NavigationViewModel { get; }
        public ILichenDetailViewModel LichenDetailViewModel { get; }     
        public MainViewModel(INavigationViewModel navigationViewModel, ILichenDetailViewModel lichenDetailViewModel)
        {
            NavigationViewModel = navigationViewModel;
            LichenDetailViewModel = lichenDetailViewModel;
       }

      

        public async Task LoadAsync()
        {
            await NavigationViewModel.LoadAsync();
        }

    }
}
 