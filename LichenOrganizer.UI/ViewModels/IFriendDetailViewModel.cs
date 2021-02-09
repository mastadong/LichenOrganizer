using System.Threading.Tasks;

namespace LichenOrganizer.UI.ViewModels
{
    public interface IFriendDetailViewModel
    {
        Task LoadAsync(int friendId);
    }
}