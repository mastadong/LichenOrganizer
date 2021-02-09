using LichenOrganizer.Model;
using LichenOrganizer.UI.Data;
using LichenOrganizer.UI.Events;
using LichenOrganizer.UI.Windows;
using LichenOrganizer.UI.Wrapper;
using Prism.Commands;
using Prism.Events;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace LichenOrganizer.UI.ViewModels
{
    public class LichenDetailViewModel : ViewModelBase, ILichenDetailViewModel
    {
        #region "Properties"
        private ILichenDataService _dataService;
        private IEventAggregator _eventAggregator;
        private LichenWrapper _lichen;
        public LichenWrapper Lichen
        {
            get { return _lichen; }
            private set
            {
                _lichen = value;
                OnPropertyChanged();
            }
        }
        #endregion

        #region "Commands"
        public ICommand SaveCommand { get; }
        public ICommand AddNewLichenCommand { get; }
        #endregion

        public LichenDetailViewModel(ILichenDataService dataService, IEventAggregator eventAggregator)
        {
            _dataService = dataService;
            _eventAggregator = eventAggregator;

            SaveCommand = new DelegateCommand(OnSaveExecute, OnSaveCanExecute);
            AddNewLichenCommand = new DelegateCommand(OnAddNewLichenExecute, OnAddNewLichenCanExecute);            

            _eventAggregator.GetEvent<OpenLichenDetailViewEvent>().Subscribe(OnOpenLichenDetailView);
        }

        

        private void OnAddNewLichenExecute()
        {
            AddNewLichenWindow addWindow = new AddNewLichenWindow();
            addWindow.ShowInTaskbar = false;
            addWindow.Owner = Application.Current.MainWindow;
            addWindow.ShowDialog();
        }

        private async void OnSaveExecute()
        {
            ////await _dataService.SaveAsync(Friend.Model);
            //_eventAggregator.GetEvent<AfterFriendSavedEvent>().Publish(
            //    new AfterFriendSavedEventArgs
            //    {
            //        Id = Friend.Id,
            //        DisplayMember = $"{Friend.FirstName} {Friend.LastName}"
            //    });
        }

        private bool OnSaveCanExecute()
        {
            //If change tracking is being implemented, insert checks here.
            return Lichen != null;
        }

        private bool OnAddNewLichenCanExecute()
        {
            return true;
        }


        private async void OnOpenLichenDetailView(int LichenId)
        {
            await LoadAsync(LichenId);
        }

        public async Task LoadAsync(int lichenId)
        {
            var lichen = await _dataService.GetByIdAsync(lichenId);
            //Instantiate the wrapper class from the returned data object.
            Lichen = new LichenWrapper(lichen);

            Lichen.PropertyChanged += (s, e) =>
            {
                if (e.PropertyName == nameof(Lichen.HasErrors))
                {
                    ((DelegateCommand)SaveCommand).RaiseCanExecuteChanged();
                }
            };
            ((DelegateCommand)SaveCommand).RaiseCanExecuteChanged();
        }





    }
}
