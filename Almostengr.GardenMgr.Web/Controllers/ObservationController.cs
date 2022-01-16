using System.Collections.Generic;
using System.Threading.Tasks;
using Almostengr.GardenMgr.Api.Controllers;
using Almostengr.GardenMgr.Api.DataTransferObjects;
using Almostengr.GardenMgr.Web.ServiceClients;
using Microsoft.AspNetCore.Mvc;

namespace Almostengr.GardenMgr.Web.Controllers
{
    public class ObservationController : BaseController, IObservationController
    {
        private readonly IObservationServiceClient _serviceClient;

        public ObservationController(IObservationServiceClient serviceClient)
        {
            _serviceClient = serviceClient;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            List<ObservationDto> result = await _serviceClient.GetRecentAsync();
            return View("Index", result);
        }

        [HttpGet]
        public async Task<IActionResult> Get(int id)
        {
            ObservationDto result = await _serviceClient.GetAsync(id);
            return View("Observation", result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            List<ObservationDto> result = await _serviceClient.GetAllAsync();
            return View("Index", result);
        }

        public async Task<IActionResult> GetRecentObservations()
        {
            List<ObservationDto> result = await _serviceClient.GetRecentAsync();
            return View("Index", result);
        }
        
    }
}