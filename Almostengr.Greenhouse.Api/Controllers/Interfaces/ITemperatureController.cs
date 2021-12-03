using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Almostengr.Greenhouse.Api.Controllers.Interfaces
{
    public interface ITemperatureController : IBaseController
    {
        Task<IActionResult> GetLastNumberOfDays(int numberOfDays);
    }    
}