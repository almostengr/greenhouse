using System.Collections.Generic;
using System.Threading.Tasks;
using Almostengr.GardenMgr.Api.DataTransferObjects;

namespace Almostengr.GardenMgr.Api.Database
{
    public interface IPlantingRepository : IBaseRepository
    {
        Task<PlantingDto> CreatePlantingAsync(PlantingDto plantingDto);
        Task<PlantingDto> GetPlantingByIdAsync(int id);
        Task<List<PlantingDto>> GetPlantingsAsync();
        Task<PlantingDto> UpdatePlantingAsync(PlantingDto plantingDto);
        Task<List<PlantingDto>> GetActivePlantingsAsync();
        Task<List<PlantingDto>> GetActivePlantingsNotFrostTolerantAsync();
        Task<List<PlantingDto>> GetPlantingsForHarvestUpdateAsync();
    }
}