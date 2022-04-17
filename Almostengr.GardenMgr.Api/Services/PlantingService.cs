using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Almostengr.Common.Twitter.Services;
using Almostengr.GardenMgr.Api.Database;
using Almostengr.GardenMgr.Api.DataTransferObjects;
using Almostengr.GardenMgr.Api.Enums;
using Microsoft.Extensions.Logging;

namespace Almostengr.GardenMgr.Api.Services
{
    public class PlantingService : BaseService, IPlantingService
    {
        private readonly IPlantingRepository _plantingRepository;
        private readonly IObservationRepository _observationRepository;
        private readonly ITwitterService _twitterService;

        public PlantingService(ILogger<PlantingService> logger, IPlantingRepository plantingRepository,
            IObservationRepository observationRepository, ITwitterService twitterService)
        {
            _plantingRepository = plantingRepository;
            _observationRepository = observationRepository;
            _twitterService = twitterService;
        }

        public async Task<PlantingDto> GetPlantingByIdAsync(int id)
        {
            return await _plantingRepository.GetPlantingByIdAsync(id);
        }

        public async Task<List<PlantingDto>> GetPlantingsAsync()
        {
            return await _plantingRepository.GetPlantingsAsync();
        }

        public async Task<PlantingDto> CreatePlantingAsync(PlantingDto plantingDto)
        {
            plantingDto.Created = DateTime.Now;
            plantingDto.Modified = plantingDto.Created;

            return await _plantingRepository.CreatePlantingAsync(plantingDto);
        }

        public async Task<PlantingDto> UpdatePlantingAsync(PlantingDto plantingDto)
        {
            plantingDto.Modified = DateTime.Now;

            return await _plantingRepository.UpdatePlantingAsync(plantingDto);
        }

        public async Task<List<PlantingDto>> GetActivePlantingsAsync()
        {
            return await _plantingRepository.GetActivePlantingsAsync();
        }

        public async Task UpdatePlantingsForHarvestAsync()
        {
            List<PlantingDto> plantingDtos = await _plantingRepository.GetPlantingsForHarvestUpdateAsync();

            DateTime currentDate = DateTime.Now;

            foreach (var plantingDto in plantingDtos)
            {
                plantingDto.PlantingStatusId = PlantingStatus.ReadyToHarvest;
                await UpdatePlantingAsync(plantingDto);
            }

            await _plantingRepository.SaveChangesAsync();

            string tweet = "";
            await _twitterService.PostTweetAsync(tweet); // post tweet
        }

        public async Task UpdatePlantingsThatFrozeAsync()
        {
            List<ObservationDto> observationDtos = await _observationRepository.GetObservationsBelowFreezingAsync();

            if (observationDtos.Count < 3)
            {
                return;
            }

            List<PlantingDto> plantingDtos = await _plantingRepository.GetActivePlantingsNotFrostTolerantAsync();

            foreach (PlantingDto plantingDto in plantingDtos)
            {
                plantingDto.PlantingStatusId = PlantingStatus.Dead;
                await UpdatePlantingAsync(plantingDto);
            }

            await _plantingRepository.SaveChangesAsync();

            string tweet = "";
            await _twitterService.PostTweetAsync(tweet); // post tweet

            return;
        }


    }
}