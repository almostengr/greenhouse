using System.Threading.Tasks;

namespace Almostengr.WeatherStation.Api.Repository.Interface
{
    public interface IBaseRepository
    {
        Task<int> SaveChangesAsync();
    }
}