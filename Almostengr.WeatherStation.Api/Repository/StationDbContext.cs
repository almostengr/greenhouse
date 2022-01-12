using Almostengr.WeatherStation.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace Almostengr.WeatherStation.Api.Repository
{
    public class StationDbContext : DbContext
    {
        public StationDbContext(DbContextOptions<StationDbContext> options) : base(options)
        {
        }
        
        public DbSet<Observation> Observations { get; set; }
    }
}