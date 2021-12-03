using System.Threading.Tasks;
using Almostengr.Greenhouse.Api.DataTransferObjects;
using Microsoft.AspNetCore.Mvc;

namespace Almostengr.Greenhouse.Api.Controllers.Interfaces
{
    public interface ISettingsController : IBaseController
    {
        Task<IActionResult> UpdateSetting(SystemSettingDto settingsDto);
        Task<IActionResult> AddSetting(SystemSettingDto settingsDto);
    }
}