using LichenOrganizer.UI.ViewModels;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace LichenOrganizer.UI.Wrapper
{
    public class NotifyDataErrorInfoBase : ViewModelBase, INotifyDataErrorInfo
    {

        //We want a way to store errors.  A dictionary is a good choice, and we'll use the property names as the keys. 
        private Dictionary<string, List<string>> _errorsByPropertyName = new Dictionary<string, List<string>>();

        //This is the property that is picked up by the WPF validation system.  The XAML file does not require any explicit inclusions for bare-bones validation to work. However, to modify
        //UI styles based on the presence/status of validation errors, additional logic must be written directly or through a resource. 
        public bool HasErrors => _errorsByPropertyName.Any();

        public event EventHandler<DataErrorsChangedEventArgs> ErrorsChanged;

        public IEnumerable GetErrors(string propertyName)
        {
            return _errorsByPropertyName.ContainsKey(propertyName) ? _errorsByPropertyName[propertyName] : null;
        }

        //We must write the three functions below.  The first is for implementing the event handler required by the interface.
        //The next two are not required, but Mr. Huber finds them to be useful helper methods for manipulating the contents of the error store. 
        protected virtual void OnErrorsChanged(string propertyName)
        {
            ErrorsChanged?.Invoke(this, new DataErrorsChangedEventArgs(propertyName));
            base.OnPropertyChanged(nameof(HasErrors));

        }


        protected void AddError(string propertyName, string error)
        {
            //Check if the dictionary contains an entry for the property name.
            if (!_errorsByPropertyName.ContainsKey(propertyName))
            {
                _errorsByPropertyName[propertyName] = new List<string>();
            }
            if (!_errorsByPropertyName[propertyName].Contains(error))
            {
                _errorsByPropertyName[propertyName].Add(error);
                OnErrorsChanged(propertyName);
            }
        }

        protected void ClearErrors(string propertyName)
        {
            //Check if the dictionary contains an entry for the property name.
            if (_errorsByPropertyName.ContainsKey(propertyName))
            {
                _errorsByPropertyName.Remove(propertyName);
                OnErrorsChanged(propertyName);
            }
        }

    }

}











