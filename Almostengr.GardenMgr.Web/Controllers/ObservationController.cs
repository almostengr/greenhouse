using System.Net.Http;
using System.Threading.Tasks;
using Almostengr.GardenMgr.Api.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace Almostengr.GardenMgr.Web.Controllers
{
    public class ObservationController : BaseController, IObservationController
    {
        public ObservationController(HttpClient httpClient, AppSettings appSettings) : base(httpClient, appSettings)
        {
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var result = await _httpClient.GetAsync("api/observation");
            return View("Index", result);
        }

        [HttpGet]
        public async Task<IActionResult> Get(int id)
        {
            var result = await _httpClient.GetAsync($"api/observation/{id}");
            return View("Observation", result);
        }

        [HttpGet]
        public async Task<IActionResult> GetLatest()
        {
            var result = await _httpClient.GetAsync("api/observation/latest");
            return View("Observation", result);
        }
    }
}