using System.Collections.Generic;
using System.Threading.Tasks;
using Almostengr.Greenhouse.Api.Models;

namespace Almostengr.Greenhouse.Api.Repository.Interfaces
{
    public interface INwsWeatherRepository : IBaseRepository<NwsWeather>
    {
        Task<IList<NwsWeather>> GetNwsWeatherAsync(string zipCode);
    }    
}