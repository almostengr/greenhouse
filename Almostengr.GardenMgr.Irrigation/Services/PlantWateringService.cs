using System.Collections.Generic;
using System.Threading.Tasks;
using Almostengr.GardenMgr.Irrigation.DataTransfer;
using Almostengr.GardenMgr.Irrigation.Database;
using Almostengr.Common.Twitter.Services;
using System;
using Microsoft.Extensions.Logging;
using Almostengr.GardenMgr.Irrigation.Relays;

namespace Almostengr.GardenMgr.Irrigation.Services
{
    public class PlantWateringService : IPlantWateringService
    {
        private readonly IPlantWateringRepository _repository;
        private readonly ITwitterService _twitterService;
        private readonly ILogger<PlantWateringService> _logger;
        private readonly IIrrigationRelay _irrigationRelay;

        public PlantWateringService(IPlantWateringRepository repository, ITwitterService twitterService,
            ILogger<PlantWateringService> logger, IIrrigationRelay irrigationRelay)
        {
            _repository = repository;
            _twitterService = twitterService;
            _logger = logger;
            _irrigationRelay = irrigationRelay;
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

        public Task<int> GetTankWaterLevel()
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> IsSoilWet(object id)
        {
            throw new System.NotImplementedException();
        }

        public void TurnOffWater(int valveGpioNumber, int pumpGpioNumber)
        {
            _irrigationRelay.TurnOffWater(valveGpioNumber);
            _irrigationRelay.TurnOffPump(pumpGpioNumber);
        }

        public async Task WaterPlantsAsync(int zoneId, int valveGpioNumber, int pumpGpioNumber, double wateringTime)
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
                _irrigationRelay.TurnOnPump(pumpGpioNumber);
                _irrigationRelay.TurnOnWater(valveGpioNumber);

                await Task.Delay(TimeSpan.FromMinutes(wateringTime));

                TurnOffWater(valveGpioNumber, pumpGpioNumber);

                PlantWateringDto watering = new PlantWateringDto()
                {
                    ZoneId = zoneId,
                    Amount = wateringTime
                };
                await _repository.CreatePlantWatering(watering);
            }
            catch (Exception ex)
            {
                TurnOffWater(valveGpioNumber, pumpGpioNumber);
                _logger.LogError(ex, ex.Message);
            }
        }

    }
}