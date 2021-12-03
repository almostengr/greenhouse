using System.Collections.Generic;
using System.Threading.Tasks;
using Almostengr.Greenhouse.Api.DataTransferObjects;

namespace Almostengr.Greehouse.Api.Services.Interfaces
{
    public interface IMoistureService
    {
        Task<MoistureDto> GetMoistureAsync(int moistureId);
        Task<MoistureDto> AddMoistureReadingAsync(MoistureDto moistureDto);
        Task<List<MoistureDto>> GetReadingForPeriodOfDaysAsync(int days);
    }
}