using System;
using System.Threading;
using System.Threading.Tasks;
using Almostengr.Common.Twitter.Services;
using Almostengr.GardenMgr.Api.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Almostengr.GardenMgr.Api.Workers
{
    public class PlantWateringWorker : BaseWorker
    {
        private readonly AppSettings _appSettings;
        private readonly ILogger<BaseWorker> _logger;
        private readonly IPlantWateringService _plantWateringService;

        public PlantWateringWorker(ILogger<BaseWorker> logger, AppSettings appSettings,
            IServiceScopeFactory factory)
        {
            _appSettings = appSettings;
            _logger = logger;
            _plantWateringService = factory.CreateScope().ServiceProvider.GetRequiredService<IPlantWateringService>();
        }

        public override Task StartAsync(CancellationToken cancellationToken)
        {
            foreach (var zone in _appSettings.Irrigation.Zones)
            {
                _plantWateringService.OpenGpio(zone.WaterGpioNumber);
                _plantWateringService.OpenGpio(zone.PumpGpioNumber);
            }

            return base.StartAsync(cancellationToken);
        }

        public override Task StopAsync(CancellationToken cancellationToken)
        {
            foreach (var zone in _appSettings.Irrigation.Zones)
            {
                _plantWateringService.CloseGpio(zone.WaterGpioNumber);
                _plantWateringService.CloseGpio(zone.PumpGpioNumber);
            }

            return base.StopAsync(cancellationToken);
        }

        protected override async Task ExecuteAsync(CancellationToken cancellationToken)
        {
            int alarmCount = 0;

            while (!cancellationToken.IsCancellationRequested)
            {
                DateTime currentDateTime = DateTime.Now;

                foreach (var zone in _appSettings.Irrigation.Zones)
                {
                    try
                    {
                        bool isTimeToWater = ((zone.WateringDays.IndexOf((int)currentDateTime.DayOfWeek) >= 0 ||
                                                zone.WateringDays.IndexOf(7) >= 0) &&
                                                currentDateTime.Hour == zone.WateringTime.Hours &&
                                                currentDateTime.Minute == zone.WateringTime.Minutes);
                        bool isWaterTankLowOrEmpty = await _plantWateringService.IsWaterTankLowOrEmpty();

                        if (isTimeToWater == true && isWaterTankLowOrEmpty == false)
                        {
                            var w = _plantWateringService.WaterPlantsAsync(zone.ZoneId, zone.WaterGpioNumber, zone.PumpGpioNumber, zone.WateringDuration);
                            alarmCount = 0;
                        }

                        if (isWaterTankLowOrEmpty && alarmCount <= 3)
                        {
                            alarmCount++;
                            _logger.LogWarning($"Alarm count {alarmCount}");
                        }
                    }
                    catch (Exception ex)
                    {
                        _logger.LogError(ex, ex.Message);
                        _plantWateringService.TurnOffWater(zone.WaterGpioNumber, zone.PumpGpioNumber);
                    }
                }

                await Task.Delay(TimeSpan.FromMinutes(1), cancellationToken);
            }
        }

    }
}