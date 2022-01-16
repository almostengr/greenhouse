using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Almostengr.GardenMgr.Api.Models;
using Almostengr.GardenMgr.Api.DataTransferObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Almostengr.GardenMgr.Api.Database
{
    public class ObservationRepository : BaseRepository, IObservationRepository
    {
        private readonly GardenDbContext _dbContext;
        private readonly ILogger<ObservationRepository> _logger;

        public ObservationRepository(GardenDbContext dbContext, ILogger<ObservationRepository> logger) : base(dbContext)
        {
            _dbContext = dbContext;
            _logger = logger;
        }

        public async Task<List<Observation>> GetObservationsOlderThanDate(DateTime date)
        {
            return await _dbContext.Observations.Where(o => o.Created < date).ToListAsync();
        }

        public void DeleteObservations(List<Observation> observations)
        {
            _dbContext.Observations.RemoveRange(observations);
        }

        public async Task CreateObservationAsync(Observation observation)
        {
            await _dbContext.Observations.AddAsync(observation);
        }

        public async Task<List<ObservationDto>> GetAllObservationsAsync()
        {
            return await _dbContext.Observations
                .OrderByDescending(o => o.Created)
                .Select(o => o.AsDto())
                .ToListAsync();
        }

        public async Task<ObservationDto> GetByObservationIdAsync(int observationId)
        {
            return await _dbContext.Observations
                .Where(o => o.ObservationId == observationId)
                .Select(o => o.AsDto())
                .SingleOrDefaultAsync();
        }

        public async Task<ObservationDto> GetLatestObservationAsync()
        {
            return await _dbContext.Observations
                .OrderByDescending(o => o.Created)
                .Take(1)
                .Select(o => o.AsDto())
                .SingleOrDefaultAsync();
        }

        public async Task<List<ObservationDto>> GetRecentObservationsAsync()
        {
            return await _dbContext.Observations
                .Where(o => o.Created > DateTime.Now.AddDays(-7))
                .OrderByDescending(o => o.Created)
                .Select(o => o.AsDto())
                .ToListAsync();
        }
    }
}
