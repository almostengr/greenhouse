using System.Threading.Tasks;
using Almostengr.GardenMgr.Irrigation.Services;
using Microsoft.AspNetCore.Mvc;

namespace Almostengr.GardenMgr.Irrigation.Controllers
{
    public class PlantWateringController : BaseApiController
    {
        private readonly IPlantWateringService _plantWateringService;

        public PlantWateringController(IPlantWateringService plantWateringService)
        {
            _plantWateringService = plantWateringService;
        }

        [HttpGet]
        public async Task<IActionResult> GetPlantWaterings()
        {
            var plantWaterings = await _plantWateringService.GetPlantWaterings();
            return Ok(plantWaterings);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPlantWatering(int id)
        {
            var plantWatering = await _plantWateringService.GetPlantWatering(id);

            if (plantWatering == null)
            {
                return NotFound($"Plant watering with id {id} not found");
            }

            return Ok(plantWatering);
        }

    }
}