using Almostengr.WeatherStation.Models;
using Microsoft.EntityFrameworkCore;

namespace Almostengr.WeatherStation.Repository
{
    public class StationDbContext : DbContext
    {
        public StationDbContext(DbContextOptions<StationDbContext> options) : base(options)
        {
        }
        
        public DbSet<Observation> Observations { get; set; }
    }
}