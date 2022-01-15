using System;
using System.Threading;
using System.Threading.Tasks;
using Almostengr.GardenMgr.Common;
using Almostengr.GardenMgr.Common.Workers;
using Almostengr.GardenMgr.WeatherStation.Sensors.Interface;
using Almostengr.GardenMgr.WeatherStation.Services.Interface;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Almostengr.GardenMgr.WeatherStation.Workers
{
    public class ObservationWorker : BaseWorker
    {
        private readonly AppSettings _appSettings;
        private readonly IObservationService _observationService;
        private readonly ISensor _sensor;
        private readonly ILogger<ObservationWorker> _logger;

        public ObservationWorker(AppSettings appSettings, IServiceScopeFactory factory,
            ILogger<ObservationWorker> logger)
        {
            _appSettings = appSettings;
            _observationService = factory.CreateScope().ServiceProvider.GetRequiredService<IObservationService>();
            _sensor = factory.CreateScope().ServiceProvider.GetRequiredService<ISensor>();
            _logger = logger;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                try
                {
                    var observationDto = await _sensor.GetSensorDataAsync();
                    await _observationService.CreateObservationAsync(observationDto);

                    await _observationService.DeleteOldObservationsAsync(_appSettings.RetentionDays);
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, ex.Message);
                }

                await Task.Delay(TimeSpan.FromMinutes(_appSettings.ReadSensorInterval), stoppingToken);
            }
        }
    }
}