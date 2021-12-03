using System.Collections.Generic;
using System.Threading.Tasks;
using Almostengr.Greenhouse.Api.DataTransferObjects;
using Almostengr.Greenhouse.Api.Models;

namespace Almostengr.Greenhouse.Api.Repository.Interfaces
{
    public interface ITemperatureRepository : IBaseRepository<Temperature>
    {
        Task<List<TemperatureDto>> GetReadingForPeriodOfDaysAsync(int days);
    }
}