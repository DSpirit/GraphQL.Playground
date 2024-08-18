using Microsoft.EntityFrameworkCore;

namespace Playground.Entities;

/// <summary>
/// SQL database context for the cinema database.
/// </summary>
public class CinemaDbContext : DbContext
{
    public DbSet<Movie> Movies { get; set; }
    public DbSet<Rating> Ratings { get; set; }

    public CinemaDbContext()
    {
    }

    public CinemaDbContext(DbContextOptions<CinemaDbContext> options) : base(options)
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseSqlite("Data Source=cinema.db");
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Rating>().ToTable("ratings");

        modelBuilder.Entity<Movie>().ToTable("movies")
            .HasMany(m => m.Ratings)
            .WithOne()
            .HasForeignKey(r => r.MovieId);

        modelBuilder.Entity<Movie>()
            .Navigation(x => x.Ratings)
            .UsePropertyAccessMode(PropertyAccessMode.Property);
    }
}