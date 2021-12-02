using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Almostengr.Greenhouse.Api.Controllers.Interfaces
{
    public interface IBaseController
    {
        Task<IActionResult> GetById(int id);
        Task<IActionResult> GetAll();
    }
}