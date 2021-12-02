using System.Threading.Tasks;
using Almostengr.Greenhouse.Api.Controllers.Interfaces;
using Almostengr.Greenhouse.Api.DataTransferObjects;
using Almostengr.Greenhouse.Api.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Almostengr.Greehouse.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TemperatureController : Controller, ITemperatureController
    {
        private readonly ITemperatureService _temperatureService;

        public TemperatureController(ITemperatureService temperatureService)
        {
            _temperatureService = temperatureService;
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetAll()
        {
            var temperatures = await _temperatureService.GetAllAsync<TemperatureDto>();
            return Ok(temperatures);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var temperature = await _temperatureService.GetByIdAsync<TemperatureDto>(id);
            
            if (temperature == null)
            {
                return NotFound();
            }

            return Ok(temperature);
        }

        public async Task<IActionResult> GetLast1Day()
        {
            var temperatures = await _temperatureService.GetAllAsync<TemperatureDto>();
            return Ok(temperatures);
        }

        public async Task<IActionResult> GetLast7Days()
        {
            var temperatures = await _temperatureService.GetAllAsync<TemperatureDto>();
            return Ok(temperatures);
        }

        public async Task<IActionResult> GetLast90Days()
        {
            var temperatures = await _temperatureService.GetAllAsync<TemperatureDto>();
            return Ok(temperatures);
        }

        public async Task<IActionResult> GetLast30Days()
        {
            var temperatures = await _temperatureService.GetAllAsync<TemperatureDto>();
            return Ok(temperatures);
        }

        public async Task<IActionResult> GetLast365Days()
        {
            var temperatures = await _temperatureService.GetAllAsync<TemperatureDto>();
            return Ok(temperatures);
        }
    }
}