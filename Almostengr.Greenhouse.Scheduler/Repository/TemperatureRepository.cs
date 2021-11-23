using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Almostengr.Greenhouse.Scheduler.Database;
using Almostengr.Greenhouse.Scheduler.Models;
using Almostengr.Greenhouse.Scheduler.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Almostengr.Greenhouse.Scheduler.Repository
{
    public class TemperatureRepository : BaseRepository<Temperature>, ITemperatureRepository
    {
        private readonly GreenhouseContext _greenhouseContext;

        public TemperatureRepository(GreenhouseContext context) : base(context)
        {
            _greenhouseContext = context;
        }

        public async Task<List<Temperature>> GetLast7DaysReadingsAsync()
        {
            return await _greenhouseContext.Temperatures
                .Where(t => t.Created >= DateTime.Now.AddDays(-7))
                .ToListAsync();
        }
        
        public async Task<List<Temperature>> GetLast30DaysReadingsAsync()
        {
            return await _greenhouseContext.Temperatures
                .Where(t => t.Created >= DateTime.Now.AddDays(-30))
                .ToListAsync();
        }

        public async Task<List<Temperature>> GetLast90DaysReadingsAsync()
        {
            return await _greenhouseContext.Temperatures
                .Where(t => t.Created >= DateTime.Now.AddDays(-90))
                .ToListAsync();
        }
    }
}