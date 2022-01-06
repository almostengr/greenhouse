using System.Collections.Generic;
using System.Threading.Tasks;
using Almostengr.WeatherStation.Api.DataTransferObjects;

namespace Almostengr.WeatherStation.Api.Services.Interface
{
    public interface IObservationService : IBaseService
    {
        Task<ObservationDto> GetByObservationIdAsync(int observationId);
        Task<IList<ObservationDto>> GetAllObservationsAsync();
        Task<ObservationDto> CreateObservationAsync(ObservationDto observationDto);
        Task<ObservationDto> GetLatestObservationAsync();
        Task DeleteOldObservationsAsync(int retentionDays);
    }
}