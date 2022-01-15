using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Almostengr.GardenMgr.Api.Models;
using Almostengr.GardenMgr.Api.DataTransferObjects;
using Almostengr.GardenMgr.Api.Database;
using Almostengr.GardenMgr.Api.Services.Interface;
using Microsoft.Extensions.Logging;

namespace Almostengr.GardenMgr.Api.Services
{
    public class ObservationService : BaseService, IObservationService
    {
        private readonly IObservationRepository _repository;
        private readonly ILogger<ObservationService> _logger;

        public ObservationService(IObservationRepository repository, ILogger<ObservationService> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        public async Task DeleteOldObservationsAsync(int retentionDays)
        {
            if (retentionDays > 0)
            {
                DateTime cutoffDate = DateTime.Now.AddDays(-retentionDays);
                List<Observation> observations = await _repository.GetObservationsOlderThanDate(cutoffDate);

                if (observations.Count > 0)
                {
                    try 
                    {
                        _repository.DeleteObservations(observations);
                        await _repository.SaveChangesAsync();

                        _logger.LogInformation($"Deleted {observations.Count} observations");
                    }
                    catch(Exception ex)
                    {
                        _logger.LogError(ex, ex.Message);
                    }
                }
            }
        }

        public async Task<ObservationDto> CreateObservationAsync(ObservationDto observationDto)
        {
            try 
            {
                if (observationDto == null)
                {
                    throw new ArgumentNullException(nameof(observationDto));
                }
                
                Observation observation = observationDto.ToObservation();
                observation.Created = DateTime.Now;

                await _repository.CreateObservationAsync(observation);
                await _repository.SaveChangesAsync();

                _logger.LogInformation($"Created observationId {observation.ObservationId}");
                
                return observation.AsDto();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return null;
            }
        }

        public async Task<IList<ObservationDto>> GetAllObservationsAsync()
        {
            return await _repository.GetAllObservationsAsync();
        }

        public async Task<ObservationDto> GetByObservationIdAsync(int observationId)
        {
            return await _repository.GetByObservationIdAsync(observationId);
        }

        public async Task<ObservationDto> GetLatestObservationAsync()
        {
            return await _repository.GetLatestObservationAsync();
        }
    }
}
