using System.Collections.Generic;
using System.Threading.Tasks;
using Almostengr.WeatherStation.DataTransferObjects;

namespace Almostengr.WeatherStation.Repository.Interface
{
    public interface IObservationRepository : IBaseRepository
    {
        Task CreateObservationAsync(ObservationDto observation);
        Task<List<ObservationDto>> GetAllObservationsAsync();
        Task<ObservationDto> GetByObservationIdAsync(int observationId);
        Task<ObservationDto> GetLatestObservationAsync();
        Task DeleteOldObservationsAsync(int retentionDays);
    }
}