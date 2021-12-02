using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Almostengr.Greenhouse.Api.Controllers.Interfaces
{
    public interface ITemperatureController : IBaseController
    {
        Task<IActionResult> GetLast1Day();
        Task<IActionResult> GetLast7Days();
        Task<IActionResult> GetLast30Days();
        Task<IActionResult> GetLast90Days();
        Task<IActionResult> GetLast365Days();
    }    
}