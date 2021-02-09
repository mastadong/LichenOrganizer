using System;
using System.Collections.Generic;
using System.Text;

namespace LichenOrganizer.UI.ViewModels
{
    public class NavigationItemViewModel : ViewModelBase
    {
        private string _displayMember;

        public string DisplayMember
        {
            get { return _displayMember; }
            set 
            { 
                _displayMember = value;
                OnPropertyChanged();
            }
        }

        public int Id { get; }

        public NavigationItemViewModel(int id, string displayMember)
        {
            Id = id;
            DisplayMember = displayMember;
        }

    }
}
