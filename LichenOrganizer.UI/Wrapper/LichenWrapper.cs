using LichenOrganizer.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace LichenOrganizer.UI.Wrapper
{

    public class LichenWrapper : ModelWrapper<Lichen>
    {
        public LichenWrapper(Lichen model) : base(model)
        {
        }

        public int Id { get { return Model.Id; } } 
        public string Genus
        {
            get { return GetValue<string>(); }
            set
            { SetValue(value); }
        }
        public string Species
        {
            get { return GetValue<string>(); }
            set { SetValue(value); }
        }
        public string County
        {
            get { return GetValue<string>(); }
            set { SetValue(value); }
        }
        public string State
        {
            get { return GetValue<string>(); }
            set { SetValue(value); }
        }
        public int Elevation
        {
            get { return GetValue<int>(); }
            set { SetValue(value); }
        }
        public string ImagePath
        {
            get { return GetValue<string>(); }
            set { SetValue(value); }
        }
        public DateTime AccessionNumber
        {
            get { return GetValue<DateTime>(); }
            set { SetValue(value); }
        }
        
        //VALIDATION RULES
        //We can set custom validation conditions here in the override method.  We can also extend the validation capabilities to incorporate the data annotations 
        //used in the Model.
        protected override IEnumerable<string> ValidateProperty(string propertyName)
        {
            switch (propertyName)
            {
                case nameof(Genus):
                    if (string.Equals(Genus, "Eggplant", StringComparison.OrdinalIgnoreCase))
                    {
                        yield return "No eggplants allowed.";
                    }
                    break;
            }
        }


    }

}











