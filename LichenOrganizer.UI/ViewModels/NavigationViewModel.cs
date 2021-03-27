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

        private ObservableCollection<NavigationItemViewModel> _lichens;

        public ObservableCollection<NavigationItemViewModel> Lichens
        {
            get { return _lichens; }
            set 
            { 
                _lichens = value;
                OnPropertyChanged();
            }
        }

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
            var unsortedList = new List<NavigationItemViewModel>();
            foreach(var item in lookup)
            {
                unsortedList.Add(new NavigationItemViewModel(item.Id, item.DisplayMember));
                //Lichens.Add(new NavigationItemViewModel(item.Id, item.DisplayMember));
            }
            List<NavigationItemViewModel> sortedList = unsortedList.OrderByDescending(i => i.DisplayMember.ToUpper()).Reverse().ToList();
            Lichens = new ObservableCollection<NavigationItemViewModel>(sortedList);
        }

    }
}
