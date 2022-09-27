using MatchDataManager.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace MatchDataManager.Api.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Team> Teams { get; set; }
        public DbSet<Location> Locations { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=LAPTOP-EMCR7O1C\\SQLEXPRESS;Database=MatchDataManagerDb;Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Location>()
                .Property(t => t.Name)
                .IsRequired()
                .HasMaxLength(255);

            modelBuilder.Entity<Location>()
                .Property(t => t.City)
                .IsRequired()
                .HasMaxLength(55);

            modelBuilder.Entity<Team>()
                .Property(t => t.Name)
                .IsRequired()
                .HasMaxLength(255);

            modelBuilder.Entity<Team>()
                .Property(t => t.CoachName)
                .HasMaxLength(55);
        }
    }
}
