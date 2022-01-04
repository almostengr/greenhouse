using System.Threading.Tasks;
using Almostengr.WeatherStation.Database;
using Almostengr.WeatherStation.Repository.Interface;

namespace Almostengr.WeatherStation.Repository
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