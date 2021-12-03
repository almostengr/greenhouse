using Almostengr.Greenhouse.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace Almostengr.Greenhouse.Api.Database
{
    public class GreenhouseContext : DbContext
    {
        public GreenhouseContext(DbContextOptions<GreenhouseContext> options) : base(options)
        {
        }

        public DbSet<Moisture> Moistures { get; set; }
        public DbSet<SystemSetting> SystemSettings { get; set; }
        public DbSet<Temperature> Temperatures { get; set; }
    }
}