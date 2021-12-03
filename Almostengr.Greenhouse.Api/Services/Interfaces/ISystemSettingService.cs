using System.Threading.Tasks;
using Almostengr.Greenhouse.Api.Common;
using Almostengr.Greenhouse.Api.DataTransferObjects;

namespace Almostengr.Greenhouse.Api.Services.Interfaces
{
    public interface ISystemSettingService
    {
        Task<SystemSettingDto> GetByKey(SettingKey key);
        Task<SystemSettingDto> GetById(int keyId);
        Task<SystemSettingDto> Create(SystemSettingDto systemSettingDto);
        Task<SystemSettingDto> Update(SystemSettingDto systemSettingDto);
    }
}