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
        private readonly ITwitterClient _twitterClient;
        private readonly IFanRelay _fanRelay;
        private const double HIGH_TEMP_ALARM_C = 35; // 95 F
        private const double LOW_TEMP_ALARM_C = 7.22; // 45 F
        private const double FAN_ON_TEMP_C = 29.44;  // 85 F
        private const double FAN_OFF_TEMP_C = 26.66; // 80 F

        public TemperatureWorker(ILogger<TemperatureWorker> logger, ITwitterClient twitterClient, AppSettings appSettings,
            IThermometerSensor thermometerSensor, IFanRelay fanRelay) :
            base(logger, twitterClient, appSettings)
        {
            _logger = logger;
            _thermomenterSensor = thermometerSensor;
            _twitterClient = twitterClient;
            _fanRelay = fanRelay;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            int minutesDelay = 30;
            int coolingStage = 0;

            while (!stoppingToken.IsCancellationRequested)
            {
                double currentTemp = await _thermomenterSensor.GetTemperatureCelsiusAsync();

                if (currentTemp >= HIGH_TEMP_ALARM_C || currentTemp <= LOW_TEMP_ALARM_C)
                {
                    await PostAlarmTweetAsync($"Temperature is {currentTemp} degrees Celsius. Please check the greenhouse.");
                }

                if (currentTemp > FAN_ON_TEMP_C)
                {
                    _fanRelay.TurnOnFan1();
                    minutesDelay = 15;

                    if (coolingStage > 1)
                    {
                        _fanRelay.TurnOnFan2(); // second stage cooling
                    }

                    coolingStage++;
                }
                else
                {
                    _fanRelay.TurnOffFan1();
                    _fanRelay.TurnOffFan2();
                    coolingStage = 0;
                    minutesDelay = 30;
                }

                await Task.Delay(TimeSpan.FromMinutes(minutesDelay), stoppingToken);
            }
        }
    }
}
