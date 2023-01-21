using System;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace Almostengr.GardenMgr.Web.ServiceClients
{
    public abstract class BaseServiceClient : IBaseServiceClient
    {
        private readonly ILogger<BaseServiceClient> _logger;
        internal HttpClient _httpClient;
        
        public BaseServiceClient(AppSettings appSettings, ILogger<BaseServiceClient> logger)
        {
            _logger = logger;
            
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri(appSettings.ApiUrl);
            _httpClient.DefaultRequestHeaders.Accept.Clear();
            _httpClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            _httpClient.Timeout = TimeSpan.FromSeconds(15);
        }

        public async Task<T> HttpGetAsync<T>(string route)
        {
            HttpResponseMessage response = await _httpClient.GetAsync(route);

            if (response.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<T>(response.Content.ReadAsStringAsync().Result);
            }
            else
            {
                _logger.LogError(response.ReasonPhrase);
                throw new Exception(response.ReasonPhrase);
            }
        }

    }
}