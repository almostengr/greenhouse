using System;
using System.Threading;
using System.Threading.Tasks;
using Almostengr.Greenhouse.Api.Relays.Interfaces;
using Almostengr.Greenhouse.Api.Sensors.Interfaces;
using Microsoft.Extensions.Logging;
using Tweetinvi;

namespace Almostengr.Greenhouse.Api.Workers
{
    public class IrrigationWorker : BaseWorker
    {
        private readonly IMoistureSensor _moistureSensor;
        private readonly IIrrigationRelay _irrigationRelay;

        public IrrigationWorker(ILogger<BaseWorker> logger, ITwitterClient twitterClient,
            IMoistureSensor moistureSensor, IIrrigationRelay irrigationRelay) :
            base(logger, twitterClient)
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
        }


    }
}