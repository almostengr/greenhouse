using System;
using System.Threading;
using System.Threading.Tasks;
using Almostengr.Greenhouse.Api.Common;
using Almostengr.Greenhouse.Api.Relays.Interfaces;
using Almostengr.Greenhouse.Api.Repository.Interfaces;
using Almostengr.Greenhouse.Api.Sensors.Interfaces;
using Microsoft.Extensions.Logging;
using Tweetinvi;

namespace Almostengr.Greenhouse.Api.Workers
{
    public class TemperatureWorker : BaseWorker
    {
        private readonly ILogger<TemperatureWorker> _logger;
        private readonly ITemperatureSensor _temperatureSensor;
        private readonly IFanRelay _fanRelay;
        private readonly IHeaterRelay _heaterRelay;
        private readonly ISystemSettingRepository _systemSettingRepo;

        public TemperatureWorker(ILogger<TemperatureWorker> logger, ITwitterClient twitterClient,
            ITemperatureSensor temperatureSensor, IFanRelay fanRelay, IHeaterRelay heaterRelay,
            ISystemSettingRepository systemSettingRepo) :
            base(logger, twitterClient)
        {
            _logger = logger;
            _temperatureSensor = temperatureSensor;
            _fanRelay = fanRelay;
            _heaterRelay = heaterRelay;
            _systemSettingRepo = systemSettingRepo;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                var currentTemp = await _temperatureSensor.GetTemperatureAsync();

                if (currentTemp.TemperatureF > await _systemSettingRepo.GetSettingValueAsDoubleAsync(SettingKey.CoolingAlarmTemperatureF) ||
                    currentTemp.TemperatureF < await _systemSettingRepo.GetSettingValueAsDoubleAsync(SettingKey.HeatingAlarmTemperatureF))
                {
                    await PostAlarmTweetAsync($"Temperature is {currentTemp}. Please check the greenhouse.");
                }

                if (currentTemp.TemperatureF > await _systemSettingRepo.GetSettingValueAsDoubleAsync(SettingKey.CoolingTargetTemperatureF))
                {
                    _fanRelay.TurnOn();
                    _heaterRelay.TurnOff();
                }
                else if (currentTemp.TemperatureF < await _systemSettingRepo.GetSettingValueAsDoubleAsync(SettingKey.HeatingTargetTemperatureF))
                {
                    _fanRelay.TurnOff();
                    _heaterRelay.TurnOn();
                }
                else
                {
                    _fanRelay.TurnOff();
                    _heaterRelay.TurnOff();
                }

                await PostTweetAsync($"Temperature is {currentTemp} C.");

                int sleepTime = await _systemSettingRepo.GetWorkerDelay();
                await Task.Delay(TimeSpan.FromMinutes(sleepTime), stoppingToken);
            }
        }

    }
}