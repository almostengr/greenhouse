using System.Collections.Generic;
using System.Threading.Tasks;
using Almostengr.GardenMgr.Api.DataTransfer;
using Almostengr.GardenMgr.Api.Database;
using Almostengr.Common.Twitter.Services;
using System;
using Microsoft.Extensions.Logging;
using Almostengr.GardenMgr.Api.Relays;

namespace Almostengr.GardenMgr.Api.Services
{
    public class PlantWateringService : IPlantWateringService
    {
        private readonly IPlantWateringRepository _repository;
        private readonly ITwitterService _twitterService;
        private readonly ILogger<PlantWateringService> _logger;
        private readonly IPlantWateringRelay _irrigationRelay;
        private readonly AppSettings _appSettings;

        public PlantWateringService(IPlantWateringRepository repository, ITwitterService twitterService,
            ILogger<PlantWateringService> logger, IPlantWateringRelay irrigationRelay, AppSettings appSettings)
        {
            _repository = repository;
            _twitterService = twitterService;
            _logger = logger;
            _irrigationRelay = irrigationRelay;
            _appSettings = appSettings;
        }

        public void CloseGpio(int gpioNumber)
        {
            _irrigationRelay.CloseGpio(gpioNumber);
        }

        public void OpenGpio(int gpioNumber)
        {
            _irrigationRelay.OpenGpio(gpioNumber);
        }

        public async Task<PlantWateringDto> CreatePlantWatering(PlantWateringDto irrigation)
        {
            return await _repository.CreatePlantWatering(irrigation);
        }

        public async Task<PlantWateringDto> GetPlantWatering(int id)
        {
            return await _repository.GetPlantWatering(id);
        }

        public async Task<List<PlantWateringDto>> GetPlantWaterings()
        {
            return await _repository.GetPlantWaterings();
        }

        public async Task<bool> IsWaterTankLowOrEmpty()
        {
            int tankWaterLevel = 0;
            TimeSpan currentTime = DateTime.Now.TimeOfDay;

            if ((currentTime.Minutes / 15) == 0 && tankWaterLevel == 0)
            {
                await _twitterService.PostAlarmTweetAsync(_appSettings.Twitter.Users, "Water tank is empty.");
                return true;
            }

            return false;
        }

        public void TurnOffWater(int waterGpioNumber, int pumpGpioNumber)
        {
            _irrigationRelay.TurnOnWater(waterGpioNumber, pumpGpioNumber);
        }

        public async Task WaterPlantsAsync(int zoneId, int waterGpioNumber, int pumpGpioNumber, double wateringTime)
        {
            try
            {
                await _twitterService.PostTweetAsync($"Watering Zone {zoneId} for {wateringTime} minutes");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
            }

            try
            {
                _irrigationRelay.TurnOnWater(waterGpioNumber, pumpGpioNumber);

                await Task.Delay(TimeSpan.FromMinutes(wateringTime));

                _irrigationRelay.TurnOnWater(waterGpioNumber, pumpGpioNumber);

                PlantWateringDto watering = new PlantWateringDto()
                {
                    ZoneId = zoneId,
                    Amount = wateringTime
                };
                await _repository.CreatePlantWatering(watering);
            }
            catch (Exception ex)
            {
                _irrigationRelay.TurnOnWater(waterGpioNumber, pumpGpioNumber);
                _logger.LogError(ex, ex.Message);
            }
        }

    }
}