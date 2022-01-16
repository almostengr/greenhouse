using System;
using System.Threading;
using System.Threading.Tasks;
using Almostengr.GardenMgr.Api.Sensors;
using Almostengr.GardenMgr.Api.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Almostengr.GardenMgr.Api.Workers
{
    public class ObservationWorker : BaseWorker
    {
        private readonly AppSettings _appSettings;
        private readonly IObservationService _observationService;
        private readonly ITemperatureSensor _tempSensor;
        private readonly ILogger<ObservationWorker> _logger;

        public ObservationWorker(AppSettings appSettings, IServiceScopeFactory factory,
            ILogger<ObservationWorker> logger)
        {
            _appSettings = appSettings;
            _observationService = factory.CreateScope().ServiceProvider.GetRequiredService<IObservationService>();
            _tempSensor = factory.CreateScope().ServiceProvider.GetRequiredService<ITemperatureSensor>();
            _logger = logger;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                try
                {
                    var observationDto = await _tempSensor.GetTemperatureDataAsync();
                    
                    await _observationService.CreateObservationAsync(observationDto);

                    var o = _observationService.DeleteOldObservationsAsync(_appSettings.RetentionDays);
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, ex.Message);
                }

                await Task.Delay(TimeSpan.FromMinutes(_appSettings.Weather.ReadTemperatureInterval), stoppingToken);
            }
        }
    }
}