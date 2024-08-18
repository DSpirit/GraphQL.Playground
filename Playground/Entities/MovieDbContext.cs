using Microsoft.EntityFrameworkCore;
using MongoDB.EntityFrameworkCore.Extensions;

namespace Playground.Entities;

public class MovieDbContext(DbContextOptions<MovieDbContext> options) : DbContext(options)
{
    public DbSet<Movie> Movies { get; set; }
    public DbSet<Rating> Ratings { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Rating>().ToCollection("ratings");

        modelBuilder.Entity<Movie>().ToCollection("movies")
            .HasMany(m => m.Ratings)
            .WithOne()
            .HasForeignKey(r => r.MovieId);

        modelBuilder.Entity<Movie>()
            .Navigation(x => x.Ratings)
            .UsePropertyAccessMode(PropertyAccessMode.Property);


    }
}