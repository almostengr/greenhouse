using System.Collections.Generic;
using System.Threading.Tasks;
using Almostengr.GardenMgr.Irrigation.Api.DataTransfer;
using Almostengr.GardenMgr.Irrigation.Api.Database;

namespace Almostengr.GardenMgr.Irrigation.Api.Services
{
    public class IrrigationService : IIrrigationService
    {
        private IIrrigationRepository _repository;

        public IrrigationService(IIrrigationRepository repository)
        {
            _repository = repository;
        }

        public async Task<IrrigationDto> CreateIrrigation(IrrigationDto irrigation)
        {
            return await _repository.CreateIrrigation(irrigation);
        }

        public async Task<IrrigationDto> GetIrrigation(int id)
        {
            return await _repository.GetIrrigation(id);
        }

        public async Task<List<IrrigationDto>> GetIrrigations()
        {
            return await _repository.GetIrrigations();
        }
    }
}