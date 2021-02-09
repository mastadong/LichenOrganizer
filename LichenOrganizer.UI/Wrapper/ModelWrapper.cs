using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace LichenOrganizer.UI.Wrapper
{
    public class ModelWrapper<T> : NotifyDataErrorInfoBase
    {
        public T Model { get; }

        public ModelWrapper(T model)
        {
            Model = model;
        }

        //GETTER
        protected virtual TValue GetValue<TValue>([CallerMemberName]string propertyName = null)
        {
            //Obtain the value from the 'PropertyInfo' object.
            return (TValue)typeof(T).GetProperty(propertyName).GetValue(Model);
        }
        //SETTER
        protected virtual void SetValue<TValue>(TValue value, [CallerMemberName] string propertyName = null)
        {
            typeof(T).GetProperty(propertyName).SetValue(Model, value);
            OnPropertyChanged(propertyName);
            ValidatePropertyInternal(propertyName, value); 
        }

        private void ValidatePropertyInternal(string propertyName, object currentValue)
        {
            //Clear all the existing errors for the property.
            ClearErrors(propertyName);

            ValidateDataAnnotations(propertyName, currentValue);

            ValidateCustomErrors(propertyName);
        }

        private void ValidateDataAnnotations(string propertyName, object currentValue)
        {
            var results = new List<ValidationResult>();
            var context = new ValidationContext(Model) { MemberName = propertyName };
            Validator.TryValidateProperty(currentValue, context, results);

            foreach (var result in results)
            {
                AddError(propertyName, result.ErrorMessage);
            }
        }

        private void ValidateCustomErrors(string propertyName)
        {
            var errors = ValidateProperty(propertyName);
            if (errors != null)
            {
                foreach (var error in errors)
                {
                    AddError(propertyName, error);
                }
            }
        }

        //Virtual method to be exposed for the client's customized validation needs.
        protected virtual IEnumerable<string> ValidateProperty(string propertyName)
        {
            return null;
        }
    }

}











