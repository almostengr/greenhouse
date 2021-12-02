using System;
using System.Threading;
using System.Threading.Tasks;
using Almostengr.Greenhouse.Api.Sensors.Interfaces;
using Microsoft.Extensions.Logging;
using Tweetinvi;

namespace Almostengr.Greenhouse.Api.Workers
{
    public class IrrigationWorker : BaseWorker
    {
        public IrrigationWorker(ILogger<BaseWorker> logger, ITwitterClient twitterClient,
            IWaterSensor waterSensor) : 
            base(logger, twitterClient)
        {
        }


        public override async Task StartAsync(CancellationToken cancellationToken)
        {
            while(!cancellationToken.IsCancellationRequested)
            {
                int timeDelay = 30;

                // check water tank level

                // if water tank level is low, send tweet

                // check moisture level

                // if moisture level is low and water tank level is not low, turn on water pump
                // run pump for 30 seconds
                // send tweet

                await Task.Delay(TimeSpan.FromMinutes(timeDelay), cancellationToken);
            }
        }

        
    }
}