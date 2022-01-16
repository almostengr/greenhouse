using System;
using System.Threading;
using System.Threading.Tasks;

namespace Almostengr.GardenMgr.Api.Workers
{
    public class PlantingWorker : BaseWorker
    {
        public PlantingWorker()
        {
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                // get the plantings that are in seedling or planted status

                // for each planting, check if it is ready to harvest based on maturity days 
                // if so, change the status to ready to harvest and send tweet

                // if temperature has dropped below freezing in the last 24 hours and plant isnt frost tolerant, change the status to dead

                await Task.Delay(TimeSpan.FromHours(24), stoppingToken);
            }
        }
    }
}