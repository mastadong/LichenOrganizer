using System.Threading.Tasks;

namespace LichenOrganizer.UI.ViewModels
{
    public interface ILichenDetailViewModel
    {
        Task LoadAsync(int friendId);
    }
}