using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Almostengr.WeatherStation.DataTransferObjects;
using Almostengr.WeatherStation.Models;
using Almostengr.WeatherStation.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Almostengr.WeatherStation.Repository
{
    public class ObservationRepository : BaseRepository, IObservationRepository
    {
        private readonly StationDbContext _dbContext;
        private readonly ILogger<ObservationRepository> _logger;

        public ObservationRepository(StationDbContext dbContext, ILogger<ObservationRepository> logger) : base(dbContext)
        {
            _dbContext = dbContext;
            _logger = logger;
        }

        public async Task DeleteObservationsAsync(List<ObservationDtos> observationDtos)
        {
            List<Observation> observations = await _dbContext.Observations.Where(o => o.Created < cutoffDate).ToListAsync();
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
                .Select(Observation.ToDto())
                .ToListAsync();
        }

        public async Task<ObservationDto> GetByObservationIdAsync(int observationId)
        {
            return await _dbContext.Observations
                .Where(o => o.ObservationId == observationId)
                .Select(Observation.ToDto())
                .SingleOrDefaultAsync();
        }

        public async Task<ObservationDto> GetLatestObservationAsync()
        {
            return await _dbContext.Observations
                .OrderByDescending(o => o.Created)
                .Take(1)
                .Select(Observation.ToDto())
                .SingleOrDefaultAsync();
        }
    }
}
