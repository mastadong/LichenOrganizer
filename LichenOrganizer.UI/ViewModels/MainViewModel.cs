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
        public IFriendDetailViewModel FriendDetailViewModel { get; }     
        public MainViewModel(INavigationViewModel navigationViewModel, IFriendDetailViewModel friendDetailViewModel)
        {
            NavigationViewModel = navigationViewModel;
            FriendDetailViewModel = friendDetailViewModel;
        }

      

        public async Task LoadAsync()
        {
            await NavigationViewModel.LoadAsync();
        }

    }
}
 