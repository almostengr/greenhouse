using System.Threading.Tasks;

namespace Almostengr.GardenMgr.WeatherStation.Repository.Interface
{
    public interface IBaseRepository
    {
        Task<int> SaveChangesAsync();
    }
}