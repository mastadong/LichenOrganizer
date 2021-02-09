using LichenOrganizer.Model;
using LichenOrganizer.UI.Data;
using LichenOrganizer.UI.Events;
using Prism.Events;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LichenOrganizer.UI.ViewModels
{
    public class NavigationViewModel : ViewModelBase, INavigationViewModel
    {
        private IFriendLookupDataService _friendLookupService;
        private IEventAggregator _eventAggregator;
        public ObservableCollection<NavigationItemViewModel> Friends { get; }
        
        private NavigationItemViewModel _selectedFriend;
        public NavigationItemViewModel SelectedFriend
        {
            get { return _selectedFriend; }
            set { 
                    _selectedFriend = value;
                    OnPropertyChanged();
                    //If a friend is selected, publish the event with the aggregator.
                    if(_selectedFriend != null)
                    {
                        _eventAggregator.GetEvent<OpenFriendDetailViewEvent>().Publish(_selectedFriend.Id);
                    }
                }
        }

        public NavigationViewModel(IFriendLookupDataService friendLookupService, IEventAggregator eventAggregator)
        {
            _friendLookupService = friendLookupService;
            _eventAggregator = eventAggregator;

            Friends = new ObservableCollection<NavigationItemViewModel>();
            _eventAggregator.GetEvent<AfterFriendSavedEvent>().Subscribe(AfterFriendSaved);
        }

        
        private void AfterFriendSaved(AfterFriendSavedEventArgs obj)
        {
            //Retrieve the corresponding LookupItem from the Friends collection
            var lookupItem = Friends.Single(l => l.Id == obj.Id);
            //Update the properties.
            if(lookupItem != null)
            {
                lookupItem.DisplayMember = obj.DisplayMember;
            }
            
        }

        public async Task LoadAsync()
        {
            var lookup = await _friendLookupService.GetFriendLookupAsync();
            Friends.Clear();
            foreach(var item in lookup)
            {
                //The friend lookup service returns a LookupItem, so we use its properties to create a new compatible collection object.
                Friends.Add(new NavigationItemViewModel(item.Id, item.DisplayMember));
            }
        }

    }
}
