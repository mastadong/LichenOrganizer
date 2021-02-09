using LichenOrganizer.Model;
using LichenOrganizer.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace LichenOrganizer.UI.Data
{
    public class FriendDataService : IFriendDataService
    {
        private Func<LichenOrganizerDbContext> _contextCreator;

        public FriendDataService(Func<LichenOrganizerDbContext> contextCreator)
        {
            _contextCreator = contextCreator;
        }

        /// <summary>
        /// Returns a single friend by Id.
        /// </summary>
        /// <returns></returns>
        public async Task<Friend> GetByIdAsync(int friendId)
        {
            using(var context = _contextCreator())
            {
                //return context.Friends.AsNoTracking().ToList();
                return await context.Friends.AsNoTracking().SingleAsync(f => f.Id == friendId);
                
            }  
        }

        /// <summary>
        /// Performs save operation on the provided friend object.
        /// </summary>
        /// <param name="friend"></param>
        /// <returns></returns>
        public async Task SaveAsync(Friend friend)
        {
            using (var context = _contextCreator())
            {
                context.Friends.Attach(friend);
                context.Entry(friend).State = EntityState.Modified;

                await context.SaveChangesAsync();
            }
        }
    }
}
