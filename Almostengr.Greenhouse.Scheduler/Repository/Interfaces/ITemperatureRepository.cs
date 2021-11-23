using System.Collections.Generic;
using System.Threading.Tasks;
using Almostengr.Greenhouse.Scheduler.Models;

namespace Almostengr.Greenhouse.Scheduler.Repository.Interfaces
{
    public interface ITemperatureRepository : IBaseRepository<Temperature>
    {
        Task<List<Temperature>> GetLast7DaysReadingsAsync();
        Task<List<Temperature>> GetLast30DaysReadingsAsync();
        Task<List<Temperature>> GetLast90DaysReadingsAsync();
    }    
}