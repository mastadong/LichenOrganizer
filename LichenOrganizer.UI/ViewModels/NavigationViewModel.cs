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
        private ILichenLookupDataService _lichenLookupService;
        private IEventAggregator _eventAggregator;
        public ObservableCollection<NavigationItemViewModel> Lichens { get; }
        
        private NavigationItemViewModel _selectedLichen;
        public NavigationItemViewModel SelectedLichen
        {
            get { return _selectedLichen; }
            set { 
                    _selectedLichen = value;
                    OnPropertyChanged();
                    //If a friend is selected, publish the event with the aggregator.
                    if(_selectedLichen != null)
                    {
                        _eventAggregator.GetEvent<OpenLichenDetailViewEvent>().Publish(_selectedLichen.Id);
                    }
                }
        }

        public NavigationViewModel(ILichenLookupDataService lichenLookupService, IEventAggregator eventAggregator)
        {
            _lichenLookupService = lichenLookupService;
            _eventAggregator = eventAggregator;

            Lichens = new ObservableCollection<NavigationItemViewModel>();
            //_eventAggregator.GetEvent<AfterFriendSavedEvent>().Subscribe(AfterFriendSaved);
        }

        
        private void AfterFriendSaved(AfterFriendSavedEventArgs obj)
        {
            //Retrieve the corresponding LookupItem from the Lichens collection
            var lookupItem = Lichens.Single(l => l.Id == obj.Id);
            //Updating the property should cause the UI to refresh.
            if(lookupItem != null)
            {
                lookupItem.DisplayMember = obj.DisplayMember;
            }
            
        }

        public async Task LoadAsync()
        {
            var lookup = await _lichenLookupService.GetLichenLookupAsync();
            Lichens.Clear();
            foreach(var item in lookup)
            {
                Lichens.Add(new NavigationItemViewModel(item.Id, item.DisplayMember));
            }
        }

    }
}
