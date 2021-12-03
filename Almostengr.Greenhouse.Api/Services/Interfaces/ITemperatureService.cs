using System.Collections.Generic;
using System.Threading.Tasks;
using Almostengr.Greenhouse.Api.DataTransferObjects;

namespace Almostengr.Greenhouse.Api.Services.Interfaces
{
    public interface ITemperatureService
    {
        Task<List<TemperatureDto>> GetReadingForPeriodOfDaysAsync(int days);
        Task<TemperatureDto> GetTemperatureByIdAsync(int id);
        Task<List<TemperatureDto>> GetTemperaturesAsync();
    }
}