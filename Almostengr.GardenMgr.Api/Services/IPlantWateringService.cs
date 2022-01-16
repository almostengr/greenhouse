using System.Collections.Generic;
using System.Threading.Tasks;
using Almostengr.GardenMgr.Api.DataTransferObjects;

namespace Almostengr.GardenMgr.Api.Services
{
    public interface IPlantWateringService
    {
        Task<List<PlantWateringDto>> GetPlantWaterings();
        Task<PlantWateringDto> GetPlantWatering(int id);
        Task<bool> IsWaterTankLowOrEmpty();
        Task WaterPlantsAsync(int zoneId, int valveGpioNumber, int pumpGpioNumber, double wateringTime);
        void TurnOffWater(int waterGpioNumber, int pumpGpioNumber);
        void OpenGpio(int waterGpioNumber);
        void CloseGpio(int waterGpioNumber);
        Task<List<PlantWateringDto>> GetRecentPlantWateringsAsync();
    }
}