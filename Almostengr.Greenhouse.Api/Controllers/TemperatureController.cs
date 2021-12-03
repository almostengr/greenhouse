using System.Threading.Tasks;
using Almostengr.Greenhouse.Api.Controllers.Interfaces;
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
            var temperatures = await _temperatureService.GetTemperaturesAsync();
            return Ok(temperatures);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var temperature = await _temperatureService.GetTemperatureByIdAsync(id);
            
            if (temperature == null)
            {
                return NotFound();
            }

            return Ok(temperature);
        }

        [HttpGet("lastdays/{numberOfDays:int}")]
        public async Task<IActionResult> GetLastNumberOfDays(int numberOfDays)
        {
            var temperatures = await _temperatureService.GetReadingForPeriodOfDaysAsync(numberOfDays);
            return Ok(temperatures);
        }
    }
}