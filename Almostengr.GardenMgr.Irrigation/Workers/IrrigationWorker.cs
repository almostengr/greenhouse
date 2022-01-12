using System;
using System.Threading;
using System.Threading.Tasks;
using Almostengr.GardenMgr.Common.Workers;
using Almostengr.GardenMgr.Irrigation.Relays;
using Almostengr.Greenhouse.Api.Sensors.Interfaces;
using Microsoft.Extensions.Logging;

namespace Almostengr.GardenMgr.Irrigation.Workers
{
    public class IrrigationWorker : BaseWorker
    {
        private readonly IMoistureSensor _moistureSensor;
        private readonly IIrrigationRelay _irrigationRelay;

        public IrrigationWorker(ILogger<BaseWorker> logger, IMoistureSensor moistureSensor, IIrrigationRelay irrigationRelay)
        {
            _moistureSensor = moistureSensor;
            _irrigationRelay = irrigationRelay;
        }

        protected override async Task ExecuteAsync(CancellationToken cancellationToken)
        {
            while (!cancellationToken.IsCancellationRequested)
            {
                int timeDelay = 30;

                // check water tank level

                // if water tank level is low, send tweet

                // check moisture level
                var moistureReading = await _moistureSensor.IsSoilWet();

                // if moisture level is low and water tank level is not low, turn on water pump
                // run pump for 30 seconds
                // send tweet
                if (moistureReading.MoistureLevel < 100)
                {
                    _irrigationRelay.TurnOnWater();
                    await Task.Delay(TimeSpan.FromSeconds(5), cancellationToken);
                }
                else
                {
                    _irrigationRelay.TurnOffWater();
                    await Task.Delay(TimeSpan.FromMinutes(timeDelay), cancellationToken);
                }



            }


            // while (!stoppingToken.IsCancellationRequested)
            // {
            //     foreach(var zone in _appSettings.Irrigation.Zones)
            //     {
            //         // check zone sensor for moisture

            //         // if moisture is low, check the water tank level

            //         // if water tank level is above empty, then irrigate

            //         // if water tank is empty, send alert to user
            //     }

            //     await Task.Delay(TimeSpan.FromMinutes(30), stoppingToken);
            // }
        }


    }
}