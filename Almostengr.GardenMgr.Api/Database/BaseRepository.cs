using System.Threading.Tasks;
using Almostengr.GardenMgr.WeatherStation.Repository;
using Almostengr.GardenMgr.WeatherStation.Repository.Interface;

namespace Almostengr.GardenMgr.Common.Database
{
    public abstract class BaseRepository : IBaseRepository
    {
        private readonly GardenDbContext _dbContext;

        public BaseRepository(GardenDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _dbContext.SaveChangesAsync();
        }
    }
}