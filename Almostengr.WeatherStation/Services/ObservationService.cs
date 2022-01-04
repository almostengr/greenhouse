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
            await _repository.DeleteOldObservationsAsync(retentionDays);
            await _repository.SaveChangesAsync();
        }

        public async Task CreateObservationAsync(ObservationDto observation)
        {
            await _repository.CreateObservationAsync(observation);
            // var result = await _repository.CreateObservationAsync(observation);
            // return result;
            await _repository.SaveChangesAsync();
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