using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Almostengr.GardenMgr.Common.Database;
using Almostengr.GardenMgr.Common.Models;
using Almostengr.GardenMgr.Irrigation.DataTransfer;
using Almostengr.GardenMgr.Irrigation.Relays;
using Microsoft.EntityFrameworkCore;

namespace Almostengr.GardenMgr.Irrigation.Database
{
    public class PlantWateringRepository : IPlantWateringRepository
    {
        private readonly GardenDbContext _context;
        private readonly IIrrigationRelay _relay;

        public PlantWateringRepository(GardenDbContext context, IIrrigationRelay relay)
        {
            _context = context;
            _relay = relay;
        }

        public async Task<List<PlantWateringDto>> GetIrrigations()
        {
            return await _context.PlantWaterings
                .Select(i => new PlantWateringDto(i))
                .ToListAsync();
        }

        public async Task<PlantWateringDto> GetIrrigation(int id)
        {
            return await _context.PlantWaterings
                .Where(i => i.Id == id)
                .Select(i => new PlantWateringDto(i))
                .SingleOrDefaultAsync();
        }

        public async Task<PlantWateringDto> CreateIrrigation(PlantWateringDto plantWateringDto)
        {
            PlantWatering plantWatering = plantWateringDto.ToPlantWatering();

            await _context.PlantWaterings.AddAsync(plantWatering);
            await _context.SaveChangesAsync();
            
            return new PlantWateringDto(plantWatering);
        }
    }
}