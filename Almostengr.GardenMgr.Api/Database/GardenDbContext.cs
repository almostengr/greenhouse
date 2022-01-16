using Almostengr.GardenMgr.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace Almostengr.GardenMgr.Api.Database
{
    public class GardenDbContext : DbContext
    {
        public GardenDbContext(DbContextOptions<GardenDbContext> options) : base(options)
        {
        }
        
        public DbSet<Observation> Observations { get; set; }
        public DbSet<Planting> Plantings { get; set; }
        public DbSet<PlantType> PlantTypes { get; set; }
        public DbSet<PlantWatering> PlantWaterings { get; set; }
    }
}