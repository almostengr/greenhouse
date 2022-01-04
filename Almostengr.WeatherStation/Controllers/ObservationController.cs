using System.Threading.Tasks;
using Almostengr.WeatherStation.Services.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Almostengr.WeatherStation.Controllers
{
    public class ObservationController : BaseController
    {
        private readonly IObservationService _service;

        public ObservationController(ILogger<ObservationController> logger, IObservationService service) : base(logger)
        {
            _service = service;
        }

        [HttpGet("{observationId:int}")]
        public async Task<IActionResult> GetByObservationId(int observationId)
        {
            var result = await _service.GetByObservationIdAsync(observationId);

            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllObservations()
        {
            var result = await _service.GetAllObservationsAsync();
            return Ok(result);
        }

        [HttpGet("latest")]
        public async Task<IActionResult> GetLatestObservation()
        {
            var result = await _service.GetLatestObservationAsync();
            return Ok(result);
        }

    }
}