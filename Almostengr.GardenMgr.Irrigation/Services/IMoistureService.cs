using System.Collections.Generic;
using System.Threading.Tasks;
using Almostengr.GardenMgr.Irrigation.DataTransferObjects;

namespace Almostengr.GardenMgr.Irrigation.Services.Interfaces
{
    public interface IMoistureService
    {
        Task<MoistureDto> GetMoistureAsync(int moistureId);
        Task<MoistureDto> AddMoistureReadingAsync(MoistureDto moistureDto);
        Task<List<MoistureDto>> GetReadingForPeriodOfDaysAsync(int days);
    }
}