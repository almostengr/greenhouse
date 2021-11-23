using Almostengr.Greenhouse.Scheduler.Models;
using Microsoft.EntityFrameworkCore;

namespace Almostengr.Greenhouse.Scheduler.Database
{
    public class GreenhouseContext : DbContext
    {
        public GreenhouseContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Temperature> Temperatures { get; set; }
        public DbSet<Precipitation> Precipitations { get; set; }
    }
}