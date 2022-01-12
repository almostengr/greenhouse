using System.Collections.Generic;
using System.Threading.Tasks;
using Almostengr.GardenMgr.Irrigation.DataTransfer;
using Almostengr.GardenMgr.Irrigation.Database;

namespace Almostengr.GardenMgr.Irrigation.Services
{
    public class PlantWateringService : IPlantWateringService
    {
        private IPlantWateringRepository _repository;

        public PlantWateringService(IPlantWateringRepository repository)
        {
            _repository = repository;
        }

        public async Task<PlantWateringDto> CreatePlantWatering(PlantWateringDto irrigation)
        {
            return await _repository.CreateIrrigation(irrigation);
        }

        public async Task<PlantWateringDto> GetPlantWatering(int id)
        {
            return await _repository.GetIrrigation(id);
        }

        public async Task<List<PlantWateringDto>> GetPlantWaterings()
        {
            return await _repository.GetIrrigations();
        }
    }
}