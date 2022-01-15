using System.Collections.Generic;
using System.Threading.Tasks;
using Almostengr.GardenMgr.Irrigation.DataTransfer;

namespace Almostengr.GardenMgr.Irrigation.Database
{
    public interface IPlantWateringRepository
    {
        Task<List<PlantWateringDto>> GetPlantWaterings();
        Task<PlantWateringDto> GetPlantWatering(int id);
        Task<PlantWateringDto> CreatePlantWatering(PlantWateringDto plantWateringDto);
    }
}