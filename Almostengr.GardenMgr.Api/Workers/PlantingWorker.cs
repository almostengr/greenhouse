using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Almostengr.GardenMgr.Api.DataTransferObjects;
using Almostengr.GardenMgr.Api.Services;

namespace Almostengr.GardenMgr.Api.Workers
{
    public class PlantingWorker : BaseWorker
    {
        private readonly IPlantingService _service;

        public PlantingWorker(IPlantingService service)
        {
            _service = service;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                await _service.UpdatePlantingsForHarvestAsync();

                // if temperature has dropped below freezing in the last 24 hours and plant isnt frost tolerant, change the status to dead
                await _service.UpdatePlantingsThatFrozeAsync();

                await Task.Delay(TimeSpan.FromHours(24), stoppingToken);
            }
        }
    }
}