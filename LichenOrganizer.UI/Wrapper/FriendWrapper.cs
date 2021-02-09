using LichenOrganizer.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace LichenOrganizer.UI.Wrapper
{

    public class FriendWrapper : ModelWrapper<Friend>
    {
        public FriendWrapper(Friend model) : base(model)
        {
        }

        public int Id { get { return Model.Id; } } 

        public string FirstName
        {
            get { return GetValue<string>(); }
            set
            { SetValue(value); }
        }

        public string LastName
        {
            get { return GetValue<string>(); }
            set { SetValue(value); }
        }

        public string Email
        {
            get { return GetValue<string>(); }
            set { SetValue(value); }
        }


        //We can set custom validation conditions here in the override method.  We can also extend the validation capabilities to incorporate the data annotations 
        //used in the Model.
        protected override IEnumerable<string> ValidateProperty(string propertyName)
        {
            switch (propertyName)
            {
                case nameof(FirstName):
                    if (string.Equals(FirstName, "Robot", StringComparison.OrdinalIgnoreCase))
                    {
                        yield return "No robots are allowed to be my friend";
                    }
                    break;
            }
        }



    }

}











