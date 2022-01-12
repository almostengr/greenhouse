using Almostengr.GardenMgr.Common.Models;
// using Almostengr.GardenMgr.WeatherStation.Models;
using Microsoft.EntityFrameworkCore;

namespace Almostengr.GardenMgr.Common.Database
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