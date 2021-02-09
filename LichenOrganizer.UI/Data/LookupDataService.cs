using LichenOrganizer.DataAccess;
using LichenOrganizer.DataAccess.Data;
using LichenOrganizer.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LichenOrganizer.UI.Data
{
    public class LookupDataService : IFriendLookupDataService
    {
        private Func<LichenOrganizerDbContext> _contextCreator;

        public LookupDataService(Func<LichenOrganizerDbContext> contextCreator)
        {
            _contextCreator = contextCreator;
        }

        public async Task<IEnumerable<LookupItem>> GetFriendLookupAsync()
        {
            using (var context = _contextCreator())
            {
                return await context.Lichens.AsNoTracking()
                    .Select(f => new LookupItem
                    {
                        Id = f.Id,
                        DisplayMember = f.Genus + " " + f.Species
                    })
                    .ToListAsync();
            }
        }


    }
}
