using System.Threading.Tasks;

namespace Almostengr.GardenMgr.Api.Database
{
    public interface IBaseRepository
    {
        Task<int> SaveChangesAsync();
    }
}