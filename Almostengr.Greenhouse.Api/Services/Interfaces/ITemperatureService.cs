using System.Collections.Generic;
using System.Threading.Tasks;
using Almostengr.Greenhouse.Api.DataTransferObjects;

namespace Almostengr.Greenhouse.Api.Services.Interfaces
{
    public interface ITemperatureService : IBaseService<TemperatureDto>
    {
        Task<List<TemperatureDto>> GetLast1DaysReadingsAsync();
        Task<List<TemperatureDto>> GetLast7DaysReadingsAsync();
        Task<List<TemperatureDto>> GetLast30DaysReadingsAsync();
        Task<List<TemperatureDto>> GetLast90DaysReadingsAsync();
        Task<List<TemperatureDto>> GetLast365DaysReadingsAsync();
    }
}