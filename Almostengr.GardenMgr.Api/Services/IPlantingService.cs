using System.Collections.Generic;
using System.Threading.Tasks;
using Almostengr.GardenMgr.Api.DataTransferObjects;

namespace Almostengr.GardenMgr.Api.Services
{
    public interface IPlantingService : IBaseService
    {
        Task<PlantingDto> CreatePlantingAsync(PlantingDto plantingDto);
        Task<List<PlantingDto>> GetActivePlantingsAsync();
        Task<PlantingDto> GetPlantingByIdAsync(int id);
        Task<List<PlantingDto>> GetPlantingsAsync();
        Task<PlantingDto> UpdatePlantingAsync(PlantingDto plantingDto);
    }
}