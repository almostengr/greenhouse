using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Almostengr.Greenhouse.Api.Common;
using Almostengr.Greenhouse.Api.Database;
using Almostengr.Greenhouse.Api.Models;
using Almostengr.Greenhouse.Api.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Almostengr.Greenhouse.Api.Repository
{
    public class SystemSettingRepository : BaseRepository<SystemSetting>, ISystemSettingRepository
    {
        private readonly GreenhouseContext _context;

        public SystemSettingRepository(GreenhouseContext context) : base(context)
        {
            _context = context;
        }

        public async Task<List<SystemSetting>> GetAllSettingsAsync()
        {
            return await _context.SystemSettings.ToListAsync();
        }

        public async Task<SystemSetting> GetSettingAsync(SettingKey key)
        {
            return await _context.SystemSettings
                .Where(s => s.Key == key)
                .SingleOrDefaultAsync();
        }

        public async Task<double> GetSettingValueAsDoubleAsync(SettingKey key)
        {
            return await _context.SystemSettings
                .Where(s => s.Key == key)
                .Select(s => double.Parse(s.Value))
                .SingleOrDefaultAsync();
        }

        public async Task<int> GetSettingValueAsIntAsync(SettingKey key)
        {
            return await _context.SystemSettings
                .Where(s => s.Key == key)
                .Select(s => Int32.Parse(s.Value))
                .SingleOrDefaultAsync();
        }

        public async Task<int> GetWorkerDelay()
        {
            int returnValue = await _context.SystemSettings
                .Where(s => s.Key == SettingKey.WorkerDelayMinutes)
                .Select(s => Int32.Parse(s.Value))
                .SingleOrDefaultAsync();

            if (returnValue == 0)
            {
                returnValue = 10;
            }

            return returnValue;
        }

        public async Task<SystemSetting> SetSettingAsync(SettingKey key, string value)
        {
            throw new System.NotImplementedException();
        }
    }
}