using LichenOrganizer.Model;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace LichenOrganizer.UI.Data
{
    public interface IFriendDataService
    {
        Task<Friend> GetByIdAsync(int friendId);
        Task SaveAsync(Friend friend);
    }
}