using BlazorApp1.Models.Fixtures;
using Microsoft.EntityFrameworkCore;

namespace BlazorApp1.Data
{
    public class UltronContext : DbContext
    {
        public UltronContext(DbContextOptions<UltronContext> options) : base(options)
        {
        }

        public DbSet<Fixture> Fixtures { get; set; } = null!;
    }
}