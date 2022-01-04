using System;
using System.Threading;
using System.Threading.Tasks;
using Almostengr.WeatherStation.DataTransferObjects;
using Almostengr.WeatherStation.Sensors.Interface;
using Almostengr.WeatherStation.Services.Interface;

namespace Almostengr.WeatherStation.Workers
{
    public class ObservationWorker : BaseWorker
    {
        private readonly AppSettings _appSettings;
        private readonly IObservationService _observationService;
        private readonly ISensor _sensor;

        public ObservationWorker(AppSettings appSettings, IObservationService observationService,
            ISensor sensor)
        {
            _appSettings = appSettings;
            _observationService = observationService;
            _sensor = sensor;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while(!stoppingToken.IsCancellationRequested)
            {
                // read from the sensor 
                var data = await _sensor.GetSensorDataAsync();

                // create a new observation with sensor Data
                ObservationDto observationDto = new();

                // write to the database
                await _observationService.CreateObservationAsync(observationDto);

                // clean old observations
                if (_appSettings.RetentionDays > 0)
                {
                    await _observationService.DeleteOldObservationsAsync(_appSettings.RetentionDays);
                }

                await Task.Delay(TimeSpan.FromMinutes(_appSettings.ReadSensorInterval), stoppingToken);
            }
        }
    }
}