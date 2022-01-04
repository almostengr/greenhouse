using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Almostengr.WeatherStation.Database;
using Almostengr.WeatherStation.DataTransferObjects;
using Almostengr.WeatherStation.Models;
using Almostengr.WeatherStation.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace Almostengr.WeatherStation.Repository
{
    public class ObservationRepository : BaseRepository, IObservationRepository
    {
        private readonly StationDbContext _dbContext;

        public ObservationRepository(StationDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task DeleteOldObservationsAsync(int retentionDays)
        {
            var cutoffDate = DateTime.Now.AddDays(-retentionDays);
            
            var observations = await _dbContext.Observations.Where(o => o.Created < cutoffDate).ToListAsync();
            _dbContext.Observations.RemoveRange(observations);
        }

        public async Task CreateObservationAsync(ObservationDto observationDto)
        {
            if (observationDto == null)
            {
                throw new ArgumentNullException(nameof(observationDto));
            }
            
            Observation observation = new Observation(observationDto);
            observation.Created = DateTime.Now;

            var newObservation = await _dbContext.Observations.AddAsync(observation);
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