using LichenOrganizer.Model;
using System.Threading.Tasks;

namespace LichenOrganizer.UI.Data
{
    public interface ILichenDataService
    {
        Task<Lichen> GetByIdAsync(int lichenId);
        Task SaveAsync(Lichen lichen);
    }
}