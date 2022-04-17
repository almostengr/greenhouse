using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Almostengr.GardenMgr.Api.DataTransferObjects;
using Almostengr.GardenMgr.Api.Enums;
using Microsoft.EntityFrameworkCore;

namespace Almostengr.GardenMgr.Api.Database
{
    public class PlantingRepository : BaseRepository, IPlantingRepository
    {
        private readonly GardenDbContext _dbContext;

        public PlantingRepository(GardenDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<PlantingDto> GetPlantingByIdAsync(int id)
        {
            return await _dbContext.Plantings
                .Where(p => p.PlantingId == id)
                .Select(p => new PlantingDto(p))
                .SingleOrDefaultAsync();
        }

        public async Task<List<PlantingDto>> GetPlantingsAsync()
        {
            return await _dbContext.Plantings
                .OrderBy(p => p.Created)
                .Select(p => new PlantingDto(p))
                .ToListAsync();
        }

        public async Task<PlantingDto> CreatePlantingAsync(PlantingDto plantingDto)
        {
            var newPlanting = plantingDto.ToPlanting();
            await _dbContext.Plantings.AddAsync(newPlanting);
            await _dbContext.SaveChangesAsync();
            return new PlantingDto(newPlanting);
        }

        public async Task<PlantingDto> UpdatePlantingAsync(PlantingDto plantingDto)
        {
            var updatedPlanting = plantingDto.ToPlanting();
            _dbContext.Plantings.Update(updatedPlanting);
            await _dbContext.SaveChangesAsync();
            return new PlantingDto(updatedPlanting);
        }

        public async Task<List<PlantingDto>> GetActivePlantingsAsync()
        {
            return await _dbContext.Plantings
                .Where(p => p.PlantingStatus == PlantingStatus.Seedling ||
                    p.PlantingStatus == PlantingStatus.Planted ||
                    p.PlantingStatus == PlantingStatus.ReadyToHarvest)
                .Select(p => new PlantingDto(p))
                .ToListAsync();
        }

        public async Task<List<PlantingDto>> GetPlantingsForHarvestUpdateAsync()
        {
            return await _dbContext.Plantings
                .Where(p => (p.PlantingStatus == PlantingStatus.Seedling || p.PlantingStatus == PlantingStatus.Planted)
                    && p.MaturityDate <= DateTime.Now)
                .Select(p => new PlantingDto(p))
                .ToListAsync();
        }

        public async Task<List<PlantingDto>> GetActivePlantingsNotFrostTolerantAsync()
        {
            return await _dbContext.Plantings
                .Where(p => (p.IsFrostTolerant == false) &&
                    (p.PlantingStatus == PlantingStatus.Seedling ||
                    p.PlantingStatus == PlantingStatus.Planted ||
                    p.PlantingStatus == PlantingStatus.ReadyToHarvest))
                .Select(p => new PlantingDto(p))
                .ToListAsync();
        }

    }
}