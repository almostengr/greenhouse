using System.Collections.Generic;
using System.Threading.Tasks;
using Almostengr.WeatherStation.DataTransferObjects;
using Almostengr.WeatherStation.Repository.Interface;
using Almostengr.WeatherStation.Services.Interface;

namespace Almostengr.WeatherStation.Services
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
                List<ObservationDto> observationDtos = await _repository.GetObservationsOlderThanDate(cutoffDate);

                if (observationDtos.Count > 0)
                {
                    try 
                    {
                        await _repository.DeleteObservationsAsync(observationDtos);
                        await _repository.SaveChangesAsync();

                        _logger.LogInformation($"Deleted {observationDtos.Count} observations");
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

                Observation observation = new Observation(observationDto);
                observation.Created = DateTime.Now;

                var newObservation = await _dbContext.Observations.AddAsync(observation);
                await _dbContext.SaveChangesAsync();

                _logger.LogInformation($"Created observationId {newObservation.Entity.ObservationId}");
                
                return new ObservationDto(newObservation);
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
