using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Almostengr.GardenMgr.Web.Controllers
{
    public class PlantWateringController : BaseController
    {
        public PlantWateringController(HttpClient httpClient, AppSettings appSettings) : base(httpClient, appSettings)
        {
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var result = await _httpClient.GetAsync("api/plantwatering");
            return View("Index", result);
        }

        [HttpGet]
        public async Task<IActionResult> Get(int id)
        {
            var result = await _httpClient.GetAsync($"api/plantwatering/{id}");
            return View("PlantWatering", result);
        }

        
    }
}