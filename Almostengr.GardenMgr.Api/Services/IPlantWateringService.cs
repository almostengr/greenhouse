using System.Collections.Generic;
using System.Threading.Tasks;
using Almostengr.GardenMgr.Api.DataTransfer;

namespace Almostengr.GardenMgr.Api.Services
{
    public interface IPlantWateringService
    {
        Task<List<PlantWateringDto>> GetPlantWaterings();
        Task<PlantWateringDto> GetPlantWatering(int id);
        // Task<PlantWateringDto> CreatePlantWatering(PlantWateringDto irrigation);
        Task<bool> IsWaterTankLowOrEmpty();
        Task WaterPlantsAsync(int zoneId, int valveGpioNumber, int pumpGpioNumber, double wateringTime);
        void TurnOffWater(int valveGpioNumber, int pumpGpioNumber);
    }
}