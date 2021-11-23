using Almostengr.Greenhouse.Scheduler.Database;
using Almostengr.Greenhouse.Scheduler.Models;
using Almostengr.Greenhouse.Scheduler.Repository.Interfaces;

namespace Almostengr.Greenhouse.Scheduler.Repository
{
    public class PrecipitationRepository : BaseRepository<Precipitation>, IPrecipitationRepository
    {
        private readonly GreenhouseContext _dbContext;

        public PrecipitationRepository(GreenhouseContext context) : base(context)
        {
            _dbContext = context;
        }

    }
}