using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Almostengr.GardenMgr.Api.Models;
using Almostengr.GardenMgr.Api.DataTransfer;
using Almostengr.GardenMgr.Api.Relays;
using Microsoft.EntityFrameworkCore;

namespace Almostengr.GardenMgr.Api.Database
{
    public class PlantWateringRepository : IPlantWateringRepository
    {
        private readonly GardenDbContext _context;
        private readonly IPlantWateringRelay _relay;

        public PlantWateringRepository(GardenDbContext context, IPlantWateringRelay relay)
        {
            _context = context;
            _relay = relay;
        }

        public async Task<List<PlantWateringDto>> GetPlantWaterings()
        {
            return await _context.PlantWaterings
                .Select(i => new PlantWateringDto(i))
                .ToListAsync();
        }

        public async Task<PlantWateringDto> GetPlantWatering(int id)
        {
            return await _context.PlantWaterings
                .Where(i => i.PlantWateringId == id)
                .Select(i => new PlantWateringDto(i))
                .SingleOrDefaultAsync();
        }

        public async Task<PlantWateringDto> CreatePlantWatering(PlantWateringDto plantWateringDto)
        {
            PlantWatering plantWatering = plantWateringDto.ToPlantWatering();

            await _context.PlantWaterings.AddAsync(plantWatering);
            await _context.SaveChangesAsync();
            
            return new PlantWateringDto(plantWatering);
        }
    }
}