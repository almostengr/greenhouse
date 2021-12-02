using Almostengr.Greenhouse.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace Almostengr.Greenhouse.Api.Database
{
    public class GreenhouseContext : DbContext
    {
        public GreenhouseContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<NwsWeather> NwsWeather { get; set; }
        public DbSet<SystemSetting> SystemSettings { get; set; }
        public DbSet<Temperature> Temperatures { get; set; }
    }
}