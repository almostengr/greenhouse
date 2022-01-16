using System.Threading.Tasks;
using Almostengr.GardenMgr.Api.DataTransferObjects;
using Almostengr.GardenMgr.Api.Services;
using Microsoft.AspNetCore.Mvc;

namespace Almostengr.GardenMgr.Api.Controllers
{
    public class PlantingController : BaseApiController
    {
        private readonly IPlantingService _service;

        public PlantingController(IPlantingService service)
        {
            _service = service;
        }
        
        [HttpGet]
        public async Task<IActionResult> GetPlantingsAsync()
        {
            var plantings = await _service.GetPlantingsAsync();
            return Ok(plantings);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPlantingByIdAsync(int id)
        {
            var planting = await _service.GetPlantingByIdAsync(id);

            if (planting == null)
            {
                return NotFound();
            }

            return Ok(planting);
        }

        [HttpPost]
        public async Task<IActionResult> CreatePlantingAsync([FromBody] PlantingDto plantingDto)
        {
            if (ModelState.IsValid == false)
            {
                return BadRequest(ModelState);
            }

            var planting = await _service.CreatePlantingAsync(plantingDto);
            return CreatedAtAction(nameof(GetPlantingByIdAsync), new { id = planting.PlantingId }, planting);
        }

        [HttpPut]
        public async Task<IActionResult> UpdatePlantingAsync([FromBody] PlantingDto plantingDto)
        {
            if (ModelState.IsValid == false)
            {
                return BadRequest(ModelState);
            }

            var response = await _service.GetPlantingByIdAsync(plantingDto.PlantingId);

            if (response == null)
            {
                return NotFound();
            }

            var planting = await _service.UpdatePlantingAsync(plantingDto);
            return Ok(planting);
        }

        [HttpGet("active")]
        public async Task<IActionResult> GetActivePlantingsAsync()
        {
            var plantings = await _service.GetActivePlantingsAsync();
            return Ok(plantings);
        }

    }
}