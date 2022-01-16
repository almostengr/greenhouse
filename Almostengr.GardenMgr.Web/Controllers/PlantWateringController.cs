using System.Collections.Generic;
using System.Threading.Tasks;
using Almostengr.GardenMgr.Api.DataTransferObjects;
using Almostengr.GardenMgr.Web.ServiceClients;
using Microsoft.AspNetCore.Mvc;

namespace Almostengr.GardenMgr.Web.Controllers
{
    public class PlantWateringController : BaseController
    {
        private readonly IPlantWateringServiceClient _serviceClient;

        public PlantWateringController(IPlantWateringServiceClient serviceClient)
        {
            _serviceClient = serviceClient;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            List<PlantWateringDto> result = await _serviceClient.GetRecentAsync();
            return View("Index", result);
        }

        [HttpGet]
        public async Task<IActionResult> Get(int id)
        {
            PlantWateringDto result = await _serviceClient.GetAsync(id);
            return View("PlantWatering", result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            List<PlantWateringDto> result = await _serviceClient.GetAllAsync();
            return View("Index", result);
        }

    }
}