using System.Collections.Generic;
using System.Threading.Tasks;
using Almostengr.GardenMgr.Api.DataTransferObjects;

namespace Almostengr.GardenMgr.Web.ServiceClients
{
    public interface IPlantWateringServiceClient : IBaseServiceClient
    {
        Task<List<PlantWateringDto>> GetAllAsync();
        Task<PlantWateringDto> GetAsync(int id);
        Task<List<PlantWateringDto>> GetRecentAsync();
    }
}