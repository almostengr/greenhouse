using Microsoft.EntityFrameworkCore;

namespace Almostengr.GardenMgr.Irrigation.Api.Database
{
    public class IrrigationDbContext : DbContext
    {
        public IrrigationDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Models.Irrigation> Irrigations { get; set; }
    }
}