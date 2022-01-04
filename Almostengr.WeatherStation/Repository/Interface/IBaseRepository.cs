using System.Threading.Tasks;

namespace Almostengr.WeatherStation.Repository.Interface
{
    public interface IBaseRepository
    {
        Task<int> SaveChangesAsync();
    }
}