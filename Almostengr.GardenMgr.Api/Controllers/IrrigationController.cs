using System.Threading.Tasks;
using Almostengr.GardenMgr.Irrigation.Api.DataTransfer;
using Almostengr.GardenMgr.Irrigation.Api.Services;
using Microsoft.AspNetCore.Mvc;

namespace Almostengr.GardenMgr.Irrigation.Api.Controllers
{
    public class IrrigationController : BaseApiController
    {
        private readonly IIrrigationService _irrigationService;

        public IrrigationController(IIrrigationService irrigationService)
        {
            _irrigationService = irrigationService;
        }

        [HttpGet]
        public async Task<IActionResult> GetIrrigations()
        {
            var irrigations = await _irrigationService.GetIrrigations();
            return Ok(irrigations);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetIrrigation(int id)
        {
            var irrigation = await _irrigationService.GetIrrigation(id);

            if (irrigation == null)
            {
                return NotFound(id);
            }

            return Ok(irrigation);
        }

        [HttpPost]
        public async Task<IActionResult> CreateIrrigation([FromBody] IrrigationDto irrigation)
        {
            if (irrigation == null)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var newIrrigation = await _irrigationService.CreateIrrigation(irrigation);

            return CreatedAtAction(nameof(GetIrrigation), new { id = newIrrigation.Id }, newIrrigation);
        }
    }
}