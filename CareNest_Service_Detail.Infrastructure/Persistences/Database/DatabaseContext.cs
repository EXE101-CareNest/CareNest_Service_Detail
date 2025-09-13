using CareNest_Service_Detail.Domain.Entitites;
using Microsoft.EntityFrameworkCore;


namespace CareNest_Service_Detail.Infrastructure.Persistences.Database
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) { }

        public DbSet<Service_Detail> Services_Details { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

        }
    }
}
