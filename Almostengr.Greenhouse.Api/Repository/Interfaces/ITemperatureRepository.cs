using System.Collections.Generic;
using System.Threading.Tasks;
using Almostengr.Greenhouse.Api.Models;

namespace Almostengr.Greenhouse.Api.Repository.Interfaces
{
    public interface ITemperatureRepository : IBaseRepository<Temperature>
    {
        Task<List<Temperature>> GetLast7DaysReadingsAsync();
        Task<List<Temperature>> GetLast30DaysReadingsAsync();
        Task<List<Temperature>> GetLast90DaysReadingsAsync();
    }    
}