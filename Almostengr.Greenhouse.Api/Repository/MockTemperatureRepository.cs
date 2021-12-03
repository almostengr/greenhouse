using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Almostengr.Greehouse.Api.Repository;
using Almostengr.Greenhouse.Api.Database;
using Almostengr.Greenhouse.Api.DataTransferObjects;
using Almostengr.Greenhouse.Api.Models;
using Almostengr.Greenhouse.Api.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Almostengr.Greenhouse.Api.Repository
{
    public class MockTemperatureRepository : BaseRepository<Temperature>, ITemperatureRepository
    {
        private readonly GreenhouseContext _context;
        public MockTemperatureRepository(GreenhouseContext context) : base(context)
        {
            _context = context;
        }

        public async Task AddAsync(Temperature entity)
        {
            throw new System.NotImplementedException();
        }

        public async Task Delete(int id)
        {
            throw new System.NotImplementedException();
        }

        public async Task<IList<TemperatureDto>> GetAllAsync()
        {
            return await _context.Temperatures
                .Select(TemperatureDto.ToTemperatureDto())
                .ToListAsync();
        }

        public async Task SaveAsync()
        {
            throw new System.NotImplementedException();
        }

        public void Update(Temperature entity)
        {
            throw new System.NotImplementedException();
        }

        public async Task<List<TemperatureDto>> GetReadingForPeriodOfDaysAsync(int days)
        {
            return await _context.Temperatures
                .Where(t => t.Created > DateTime.Now.AddDays(-days))
                .Select(TemperatureDto.ToTemperatureDto())
                .ToListAsync();
        }
    }
}