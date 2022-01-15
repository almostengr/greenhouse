using System.Threading.Tasks;

namespace Almostengr.GardenMgr.Api.Database
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