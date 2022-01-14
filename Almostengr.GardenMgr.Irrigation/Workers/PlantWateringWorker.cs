using System;
using System.Threading;
using System.Threading.Tasks;
using Almostengr.Common.Twitter.Services;
using Almostengr.GardenMgr.Common;
using Almostengr.GardenMgr.Common.Workers;
using Almostengr.GardenMgr.Irrigation.Services;
using Microsoft.Extensions.Logging;

namespace Almostengr.GardenMgr.Irrigation.Workers
{
    public class PlantWateringWorker : BaseWorker
    {
        private readonly AppSettings _appSettings;
        private readonly ILogger<BaseWorker> _logger;
        private readonly IPlantWateringService _plantWateringService;
        private readonly ITwitterService _twitterService;

        public PlantWateringWorker(ILogger<BaseWorker> logger, AppSettings appSettings,
            ITwitterService twitterService, IPlantWateringService plantWateringService)
        {
            _appSettings = appSettings;
            _logger = logger;
            _plantWateringService = plantWateringService;
            _twitterService = twitterService;
        }

        protected override async Task ExecuteAsync(CancellationToken cancellationToken)
        {
            int alarmCount = 0;

            while (!cancellationToken.IsCancellationRequested)
            {
                TimeSpan currentTime = DateTime.Now.TimeOfDay;

                foreach (var zone in _appSettings.Irrigation.Zones)
                {
                    try
                    {
                        bool isZoneWet = await _plantWateringService.IsSoilWet(zone.ZoneId);
                        bool isTimeToWater = (currentTime == zone.WateringTime);
                        int tankWaterLevel = await _plantWateringService.GetTankWaterLevel();

                        if (isTimeToWater == true && tankWaterLevel > 0)
                        {
                            var w = _plantWateringService.WaterPlantsAsync(zone.ZoneId, zone.ValveGpioNumber, zone.PumpGpioNumber, zone.WateringDuration);
                            alarmCount = 0;
                        }

                        if ((currentTime.Minutes/15) == 0 && tankWaterLevel == 0 && alarmCount <= 3)
                        {
                            await _twitterService.PostAlarmTweetAsync(_appSettings.Twitter.Users, "Water tank is empty.");
                            alarmCount++;
                        }
                    }
                    catch (Exception ex)
                    {
                        _logger.LogError(ex, ex.Message);
                        _plantWateringService.TurnOffWater(zone.ValveGpioNumber, zone.PumpGpioNumber);
                    }
                }

                await Task.Delay(TimeSpan.FromMinutes(1), cancellationToken);
            }
        }

    }
}