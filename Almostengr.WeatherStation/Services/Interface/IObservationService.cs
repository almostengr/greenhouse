using System.Collections.Generic;
using System.Threading.Tasks;
using Almostengr.WeatherStation.DataTransferObjects;

namespace Almostengr.WeatherStation.Services.Interface
{
    public interface IObservationService : IBaseService
    {
        Task<ObservationDto> GetByObservationIdAsync(int observationId);
        Task<IList<ObservationDto>> GetAllObservationsAsync();
        Task CreateObservationAsync(ObservationDto observation);
        // Task<ObservationDto> CreateObservationAsync(ObservationDto observation);
        Task<ObservationDto> GetLatestObservationAsync();
        Task DeleteOldObservationsAsync(int retentionDays);
    }
}