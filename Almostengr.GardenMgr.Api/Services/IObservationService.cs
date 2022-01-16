using System.Collections.Generic;
using System.Threading.Tasks;
using Almostengr.GardenMgr.Api.DataTransferObjects;

namespace Almostengr.GardenMgr.Api.Services
{
    public interface IObservationService : IBaseService
    {
        Task<ObservationDto> GetByObservationIdAsync(int observationId);
        Task<IList<ObservationDto>> GetAllObservationsAsync();
        Task<ObservationDto> CreateObservationAsync(ObservationDto observationDto);
        Task<ObservationDto> GetLatestObservationAsync();
        Task DeleteOldObservationsAsync(int retentionDays);
        Task<List<ObservationDto>> GetRecentObservationsAsync();
    }
}