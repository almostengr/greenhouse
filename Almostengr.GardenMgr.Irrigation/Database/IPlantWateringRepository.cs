using System.Collections.Generic;
using System.Threading.Tasks;
using Almostengr.GardenMgr.Irrigation.DataTransfer;

namespace Almostengr.GardenMgr.Irrigation.Database
{
    public interface IPlantWateringRepository
    {
        Task<List<PlantWateringDto>> GetIrrigations();
        Task<PlantWateringDto> GetIrrigation(int id);
        Task<PlantWateringDto> CreateIrrigation(PlantWateringDto irrigation);
    }
}