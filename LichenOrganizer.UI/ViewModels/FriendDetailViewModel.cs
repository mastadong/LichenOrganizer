using LichenOrganizer.Model;
using LichenOrganizer.UI.Data;
using LichenOrganizer.UI.Events;
using LichenOrganizer.UI.Wrapper;
using Prism.Commands;
using Prism.Events;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace LichenOrganizer.UI.ViewModels
{
    public class FriendDetailViewModel : ViewModelBase, IFriendDetailViewModel
    {
        private IFriendDataService _dataService;
        private IEventAggregator _eventAggregator;
        private FriendWrapper _friend;


        public FriendDetailViewModel(IFriendDataService dataService, IEventAggregator eventAggregator)
        {
            _dataService = dataService;
            _eventAggregator = eventAggregator;
            //Subscribe to aggregator events here by passing in a method to handle the event when it is triggered.
            _eventAggregator.GetEvent<OpenFriendDetailViewEvent>().Subscribe(OnOpenFriendDetailView);

            SaveCommand = new DelegateCommand(OnSaveExecute, OnSaveCanExecute);
        }
        public ICommand SaveCommand { get; }
        public FriendWrapper Friend
        {
            get { return _friend; }
            private set
            {
                _friend = value;
                OnPropertyChanged();
            }
        }
        
        //GET BY ID
        public async Task LoadAsync(int friendId)
        {
            var friend = await _dataService.GetByIdAsync(friendId);
            //Instantiate the wrapper class from the returned data object.
            Friend = new FriendWrapper(friend);

            Friend.PropertyChanged += (s, e) =>
            {
                if (e.PropertyName == nameof(Friend.HasErrors))
                {
                    ((DelegateCommand)SaveCommand).RaiseCanExecuteChanged();
                }
            };
            ((DelegateCommand)SaveCommand).RaiseCanExecuteChanged();
        }

        private async void OnSaveExecute()
        {
            await _dataService.SaveAsync(Friend.Model);
            _eventAggregator.GetEvent<AfterFriendSavedEvent>().Publish(
                new AfterFriendSavedEventArgs
                {
                    Id = Friend.Id,
                    DisplayMember = $"{Friend.FirstName} {Friend.LastName}"
                });
        }

        private bool OnSaveCanExecute()
        {
            //TODO: Check in addition if friend has changes.  By this, I mean the Save button will be disabled if the user doesn't actually change
            //any properties of the current Friend.
            return Friend!=null && !Friend.HasErrors;
        }

        /// <summary>
        /// Handler that subscribes to the aggregator event for selecting an individual friend.
        /// </summary>
        /// <param name="friendId"></param>
        private async void OnOpenFriendDetailView(int friendId)
        {
            await LoadAsync(friendId);
        }







    }
}
