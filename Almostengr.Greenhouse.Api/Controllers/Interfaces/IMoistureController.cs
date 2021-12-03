using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Almostengr.Greenhouse.Api.Controllers.Interfaces
{
    public interface IMoistureController : IBaseController
    {
        Task<IActionResult> GetLastNumberOfDays(int numberOfDays);
    }
}