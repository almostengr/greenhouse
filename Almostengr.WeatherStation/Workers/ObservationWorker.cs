using System;
using System.Threading;
using System.Threading.Tasks;
using Almostengr.WeatherStation.Sensors.Interface;
using Almostengr.WeatherStation.Services.Interface;
using Microsoft.Extensions.DependencyInjection;

namespace Almostengr.WeatherStation.Workers
{
    public class ObservationWorker : BaseWorker
    {
        private readonly AppSettings _appSettings;
        private readonly IObservationService _observationService;
        private readonly ISensor _sensor;

        public ObservationWorker(AppSettings appSettings, IServiceScopeFactory factory)
        {
            _appSettings = appSettings;
            _observationService = factory.CreateScope().ServiceProvider.GetRequiredService<IObservationService>();
            _sensor = factory.CreateScope().ServiceProvider.GetRequiredService<ISensor>();
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while(!stoppingToken.IsCancellationRequested)
            {
                var observationDto = await _sensor.GetSensorDataAsync();

                await _observationService.CreateObservationAsync(observationDto);

                await _observationService.DeleteOldObservationsAsync(_appSettings.RetentionDays);

                await Task.Delay(TimeSpan.FromMinutes(_appSettings.ReadSensorInterval), stoppingToken);
            }
        }
    }
}