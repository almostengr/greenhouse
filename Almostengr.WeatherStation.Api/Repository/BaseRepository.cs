using System.Threading.Tasks;
using Almostengr.WeatherStation.Api.Repository;
using Almostengr.WeatherStation.Api.Repository.Interface;

namespace Almostengr.WeatherStation.Api.Repository
{
    public abstract class BaseRepository : IBaseRepository
    {
        private readonly StationDbContext _dbContext;

        public BaseRepository(StationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _dbContext.SaveChangesAsync();
        }
    }
}