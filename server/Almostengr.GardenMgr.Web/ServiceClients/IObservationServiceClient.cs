using System.Collections.Generic;
using System.Threading.Tasks;
using Almostengr.GardenMgr.Api.DataTransferObjects;

namespace Almostengr.GardenMgr.Web.ServiceClients
{
    public interface IObservationServiceClient : IBaseServiceClient
    {
        Task<List<ObservationDto>> GetAllAsync();
        Task<ObservationDto> GetAsync(int id);
        Task<ObservationDto> GetLatestAsync();
        Task<List<ObservationDto>> GetRecentAsync();
    }
}