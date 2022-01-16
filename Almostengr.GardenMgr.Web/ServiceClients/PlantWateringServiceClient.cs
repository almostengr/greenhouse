using System.Collections.Generic;
using System.Threading.Tasks;
using Almostengr.GardenMgr.Api.DataTransferObjects;
using Microsoft.Extensions.Logging;

namespace Almostengr.GardenMgr.Web.ServiceClients
{
    public class PlantWateringServiceClient : BaseServiceClient, IPlantWateringServiceClient
    {
        public PlantWateringServiceClient(AppSettings appSettings, ILogger<PlantWateringServiceClient> logger) : base(appSettings, logger)
        {
        }

        public async Task<List<PlantWateringDto>> GetAllAsync()
        {
            return await HttpGetAsync<List<PlantWateringDto>>("api/plantwaterings");
        }

        public async Task<PlantWateringDto> GetAsync(int id)
        {
            return await HttpGetAsync<PlantWateringDto>($"api/plantwaterings/{id}");
        }

        public async Task<List<PlantWateringDto>> GetRecentAsync()
        {
            return await HttpGetAsync<List<PlantWateringDto>>("api/plantwaterings/recent");
        }
    }
}