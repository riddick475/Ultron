using BlazorApp1.Models.Fixtures;
using BlazorApp1.Models.Predictions;
using Microsoft.EntityFrameworkCore;

namespace BlazorApp1.Data
{
    public class UltronContext : DbContext
    {
        public UltronContext(DbContextOptions<UltronContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            if (modelBuilder == null) return;
            modelBuilder.Entity<Fixture>().HasOne(x => x.League);
            modelBuilder.Entity<Fixture>().HasOne(x => x.Awayteam);
            modelBuilder.Entity<Fixture>().HasOne(x => x.HomeTeam);
            modelBuilder.Entity<Fixture>().HasOne(x => x.Score);
        }
        public DbSet<Fixture> Fixtures { get; set; } = null!;
        public DbSet<ForebetPrediction1X2> Forebet1X2Predictions { get; set; } = null!;
    }
}