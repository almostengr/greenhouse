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

        public ObservationService(IObservationRepository repository)
        {
            _repository = repository;
        }

        public async Task DeleteOldObservationsAsync(int retentionDays)
        {
            if (retentionDays > 0)
            {
                await _repository.DeleteOldObservationsAsync(retentionDays);
            }
        }

        public async Task CreateObservationAsync(ObservationDto observation)
        {
            await _repository.CreateObservationAsync(observation);
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