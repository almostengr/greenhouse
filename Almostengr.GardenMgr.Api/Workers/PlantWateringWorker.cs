using System;
using System.Threading;
using System.Threading.Tasks;
using Almostengr.Common.Twitter.Services;
using Almostengr.GardenMgr.Api;
using Almostengr.GardenMgr.Api.Workers;
using Almostengr.GardenMgr.Api.Services;
using Microsoft.Extensions.Logging;

namespace Almostengr.GardenMgr.Api.Workers
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
                        bool isTimeToWater = (currentTime.Hours == zone.WateringTime.Hours &&
                                              currentTime.Minutes == zone.WateringTime.Minutes);
                        bool isWaterTankLowOrEmpty = await _plantWateringService.IsWaterTankLowOrEmpty();

                        if (isTimeToWater == true && isWaterTankLowOrEmpty == false)
                        {
                            var w = _plantWateringService.WaterPlantsAsync(zone.ZoneId, zone.ValveGpioNumber, zone.PumpGpioNumber, zone.WateringDuration);
                            alarmCount = 0;
                        }

                        if (isWaterTankLowOrEmpty && alarmCount <= 3)
                        {
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