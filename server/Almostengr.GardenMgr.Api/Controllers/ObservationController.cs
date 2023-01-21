using System.Threading.Tasks;
using Almostengr.GardenMgr.Api.DataTransferObjects;
using Almostengr.GardenMgr.Api.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Almostengr.GardenMgr.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]s")]
    public class ObservationController : ControllerBase, IObservationController
    {
        private readonly IObservationService _service;

        public ObservationController(ILogger<ObservationController> logger, IObservationService service)
        {
            _service = service;
        }

        [HttpGet("{observationId:int}")]
        public async Task<IActionResult> GetObservationById(int observationId)
        {
            ObservationDto result = await _service.GetByObservationIdAsync(observationId);

            if (result == null)
            {
                return NotFound($"Observation with id {observationId} not found");
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

        [HttpGet("recent")]
        public async Task<IActionResult> GetRecentObservations()
        {
            var result = await _service.GetRecentObservationsAsync();
            return Ok(result);
        }

    }
}