using LichenOrganizer.Model;
using LichenOrganizer.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using LichenOrganizer.DataAccess.Data;

namespace LichenOrganizer.UI.Data
{
    public class LichenDataService : ILichenDataService
    {
        private Func<LichenOrganizerDbContext> _contextCreator;

        public LichenDataService(Func<LichenOrganizerDbContext> contextCreator)
        {
            _contextCreator = contextCreator;
        }

        /// <summary>
        /// Returns a single friend by Id.
        /// </summary>
        /// <returns></returns>
        public async Task<Lichen> GetByIdAsync(int lichenId)
        {
            using (var context = _contextCreator())
            {
                //return context.Friends.AsNoTracking().ToList();
                return await context.Lichens.AsNoTracking().SingleAsync(f => f.Id == lichenId);

            }
        }

        /// <summary>
        /// Performs save operation on the provided friend object.
        /// </summary>
        /// <param name="friend"></param>
        /// <returns></returns>
        public async Task SaveAsync(Lichen lichen)
        {
            using (var context = _contextCreator())
            {
                context.Lichens.Attach(lichen);
                context.Entry(lichen).State = EntityState.Modified;

                await context.SaveChangesAsync();
            }
        }
    }
}
