using System;
using System.Threading;
using System.Threading.Tasks;
using Almostengr.Greenhouse.Scheduler.Common;
using Almostengr.Greenhouse.Scheduler.Relays.Interfaces;
using Almostengr.Greenhouse.Scheduler.Sensors.Interface;
using Microsoft.Extensions.Logging;
using Tweetinvi;

namespace Almostengr.Greenhouse.Scheduler.Workers
{
    public class TemperatureWorker : BaseWorker
    {
        private readonly ILogger<TemperatureWorker> _logger;
        private readonly IThermometerSensor _thermomenterSensor;
        private readonly IFanRelay _fanRelay;
        private readonly IHeaterRelay _heaterRelay;
        private const double HIGH_TEMP_ALARM_C = 35; // 95 F
        private const double LOW_TEMP_ALARM_C = 7.22; // 45 F
        private const double HIGH_TEMP_RANGE = 29.44; // 85 F
        private const double LOW_TEMP_RANGE = 12.77; // 50 F

        public TemperatureWorker(ILogger<TemperatureWorker> logger, ITwitterClient twitterClient, AppSettings appSettings,
            IThermometerSensor thermometerSensor, IFanRelay fanRelay, IHeaterRelay heaterRelay) :
            base(logger, twitterClient, appSettings)
        {
            _logger = logger;
            _thermomenterSensor = thermometerSensor;
            _fanRelay = fanRelay;
            _heaterRelay = heaterRelay;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            int counter = 0;
            while (!stoppingToken.IsCancellationRequested)
            {
                double currentTemp = await _thermomenterSensor.GetTemperatureCelsiusAsync();
                _logger.LogInformation($"Current temperature is {currentTemp} C");

                if (currentTemp >= HIGH_TEMP_ALARM_C || currentTemp <= LOW_TEMP_ALARM_C)
                {
                    await PostAlarmTweetAsync($"Temperature is {currentTemp} degrees Celsius. Please check the greenhouse.");
                }

                if (currentTemp > HIGH_TEMP_RANGE)
                {
                    _fanRelay.TurnOnFan1();
                    _heaterRelay.TurnOff1();
                }
                else if (currentTemp < LOW_TEMP_RANGE)
                {
                    _fanRelay.TurnOffFan1();
                    _heaterRelay.TurnOn1();
                }
                else
                {
                    _fanRelay.TurnOffFan1();
                    _heaterRelay.TurnOff1();
                }

                await PostTweetAsync($"Temperature is {currentTemp} C.");

                counter++;

                await Task.Delay(TimeSpan.FromMinutes(15), stoppingToken);
            }
        }
    }
}
