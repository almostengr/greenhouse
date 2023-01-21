using System.Collections.Generic;
using System.Threading.Tasks;
using Almostengr.GardenMgr.Api.DataTransferObjects;
using Microsoft.Extensions.Logging;

namespace Almostengr.GardenMgr.Web.ServiceClients
{
    public class ObservationServiceClient : BaseServiceClient, IObservationServiceClient
    {
        public ObservationServiceClient(AppSettings appSettings, ILogger<ObservationServiceClient> logger) : base(appSettings, logger)
        {
        }

        public async Task<List<ObservationDto>> GetAllAsync()
        {
            return await HttpGetAsync<List<ObservationDto>>("api/observations");
        }

        public async Task<ObservationDto> GetAsync(int id)
        {
            return await HttpGetAsync<ObservationDto>($"api/observations/{id}");
        }
        
        public async Task<ObservationDto> GetLatestAsync()
        {
            return await HttpGetAsync<ObservationDto>("api/observations/latest");
        }

        public async Task<List<ObservationDto>> GetRecentAsync()
        {
            return await HttpGetAsync<List<ObservationDto>>("api/observations/recent");
        }
    }
}