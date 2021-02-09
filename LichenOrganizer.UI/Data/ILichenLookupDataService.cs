using LichenOrganizer.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LichenOrganizer.UI.Data
{
    public interface ILichenLookupDataService
    {
        Task<IEnumerable<LookupItem>> GetLichenLookupAsync();
    }
}
