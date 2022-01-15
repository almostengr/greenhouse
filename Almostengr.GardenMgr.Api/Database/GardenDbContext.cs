using Almostengr.GardenMgr.Api.Models;
// using Almostengr.GardenMgr.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace Almostengr.GardenMgr.Api.Database
{
    public class GardenDbContext : DbContext
    {
        public GardenDbContext(DbContextOptions<GardenDbContext> options) : base(options)
        {
        }
        
        public DbSet<PlantWatering> PlantWaterings { get; set; }
        public DbSet<Observation> Observations { get; set; }
    }
}