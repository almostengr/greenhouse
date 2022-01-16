using System.Collections.Generic;
using System.Threading.Tasks;
using Almostengr.GardenMgr.Api.Database;
using Almostengr.GardenMgr.Api.DataTransferObjects;
using Microsoft.Extensions.Logging;

namespace Almostengr.GardenMgr.Api.Services
{
    public class PlantingService : BaseService, IPlantingService
    {
        private readonly IPlantingRepository _plantingRepository;

        public PlantingService(ILogger<PlantingService> logger, IPlantingRepository plantingRepository)
        {
            _plantingRepository = plantingRepository;
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
            return await _plantingRepository.CreatePlantingAsync(plantingDto);
        }

        public async Task<PlantingDto> UpdatePlantingAsync(PlantingDto plantingDto)
        {   
            return await _plantingRepository.UpdatePlantingAsync(plantingDto);
        }

        public async Task<List<PlantingDto>> GetActivePlantingsAsync()
        {
            return await _plantingRepository.GetActivePlantingsAsync();
        }
    }
}