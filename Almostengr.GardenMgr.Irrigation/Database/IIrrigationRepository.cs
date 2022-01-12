using System.Collections.Generic;
using System.Threading.Tasks;
using Almostengr.GardenMgr.Irrigation.Api.DataTransfer;

namespace Almostengr.GardenMgr.Irrigation.Api.Database
{
    public interface IIrrigationRepository
    {
        Task<List<IrrigationDto>> GetIrrigations();
        Task<IrrigationDto> GetIrrigation(int id);
        Task<IrrigationDto> CreateIrrigation(IrrigationDto irrigation);
    }
}