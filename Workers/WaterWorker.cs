using System;
using System.Threading;
using System.Threading.Tasks;
using Almostengr.Greenhouse.Api.Common;
using Almostengr.Greenhouse.Api.Relays.Interfaces;
using Microsoft.Extensions.Logging;
using Tweetinvi;

namespace Almostengr.Greenhouse.Api.Workers
{
    public class WaterWorker : BaseWorker
    {
        private readonly ILogger<WaterWorker> _logger;
        private readonly AppSettings _appSettings;
        private readonly IWaterRelay _waterRelay;

        public WaterWorker(ILogger<WaterWorker> logger, ITwitterClient twitterClient, AppSettings appSettings,
        IWaterRelay waterRelay) : 
            base(logger, twitterClient, appSettings)
        {
            _logger = logger;
            _appSettings = appSettings;
            _waterRelay = waterRelay;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            int tankLevel = 0;
            int minutesDelay = 30;

            while (!stoppingToken.IsCancellationRequested)
            {
                // DateTime currentDateTime = DateTime.Now;
                TimeSpan currentTime = DateTime.Now.TimeOfDay;

                // check water tank level

                if (tankLevel == 0)
                {
                    // alarm if level is below threshold
                    await PostAlarmTweetAsync("Water tank level is low");
                }
                else if (tankLevel == 2)
                {
                    // alarm and water if level is above threshold
                    await PostAlarmTweetAsync("Water tank level is high");
                }

                if (tankLevel == 2)
                {
                    _waterRelay.TurnOnWater1();
                    _waterRelay.TurnOnWater2();
                    minutesDelay = 2;
                }
                else {
                    _waterRelay.TurnOffWater1();
                    _waterRelay.TurnOffWater2();
                    minutesDelay = 120;
                }

                await Task.Delay(TimeSpan.FromMinutes(minutesDelay), stoppingToken);
            }
        }
    }
}
