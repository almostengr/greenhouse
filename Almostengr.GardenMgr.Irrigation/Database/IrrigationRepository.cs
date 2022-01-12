using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Almostengr.GardenMgr.Irrigation.Api.DataTransfer;
using Almostengr.GardenMgr.Irrigation.Api.Models;
using Almostengr.GardenMgr.Irrigation.Api.Relays;
using Microsoft.EntityFrameworkCore;

namespace Almostengr.GardenMgr.Irrigation.Api.Database
{
    public class IrrigationRepository : IIrrigationRepository
    {
        private readonly IrrigationDbContext _context;
        private readonly IIrrigationRelay _relay;

        public IrrigationRepository(IrrigationDbContext context, IIrrigationRelay relay)
        {
            _context = context;
            _relay = relay;
        }

        public async Task<List<IrrigationDto>> GetIrrigations()
        {
            return await _context.Irrigations
                .Select(i => i.ToIrrigationDto())
                .ToListAsync();
        }

        public async Task<IrrigationDto> GetIrrigation(int id)
        {
            return await _context.Irrigations
                .Where(i => i.Id == id)
                .Select(i => i.ToIrrigationDto())
                .SingleOrDefaultAsync();
        }

        public async Task<IrrigationDto> CreateIrrigation(IrrigationDto irrigationDto)
        {
            Models.Irrigation irrigation = new Models.Irrigation(irrigationDto);

            await _context.Irrigations.AddAsync(irrigation);
            await _context.SaveChangesAsync();
            
            return irrigation.ToIrrigationDto();
        }
    }
}