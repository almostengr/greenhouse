using System.Collections.Generic;
using System.Threading.Tasks;
using Almostengr.Greenhouse.Api.Common;
using Almostengr.Greenhouse.Api.Models;

namespace Almostengr.Greenhouse.Api.Repository.Interfaces
{
    public interface ISystemSettingRepository
    {
        Task<SystemSetting> SetSettingAsync(SettingKey key, string value);
        Task<SystemSetting> GetSettingAsync(SettingKey key);
        Task<double> GetSettingValueAsDoubleAsync(SettingKey key);
        Task<List<SystemSetting>> GetAllSettingsAsync();
        Task<int> GetSettingValueAsIntAsync(SettingKey workerDelayMinutes);
        Task<int> GetWorkerDelay();
    }
}