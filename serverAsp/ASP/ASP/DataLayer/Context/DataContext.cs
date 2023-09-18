using Microsoft.EntityFrameworkCore;
using ASP.DataLayer.Models;

namespace ASP.DataLayer.Context;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions options)
        : base(options)
    {
    }


    public DbSet<Hero> Heroes { get; set; } = null!;
    public DbSet<User> Users { get; set; } = null!;
    public DbSet<HeroToUsers> HeroToUsers { get; set; } = null!;
    public DbSet<Power> Powers { get; set; } = null!;
    public DbSet<Stats> Stats { get; set; } = null!;
    public DbSet<Roles> Roles { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Hero>()
            .HasOne(h => h.Roles)
            .WithOne(r => r.Hero)
            .HasForeignKey<Roles>(r => r.HeroId);


        modelBuilder.Entity<Hero>()
            .HasOne(h => h.Stats)
            .WithOne(r => r.Hero)
            .HasForeignKey<Stats>(stats => stats.HeroId);
    }

}