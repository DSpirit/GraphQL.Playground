using Microsoft.EntityFrameworkCore;
using Playground.Entities;
using Playground.Interfaces;

namespace Playground.Repositories;

public class CinemaRepository(CinemaDbContext movieDbContext) : IMovieRepository, ICinemaRepository
{
    public IEnumerable<Movie> GetMovies()
    {
        return movieDbContext.Movies.Include(x => x.Ratings).ToList();
    }

    public Movie GetMovie(Guid id)
    {
        return movieDbContext.Movies.Find(id) ?? throw new Exception("Movie not found");
    }

    public void AddMovie(Movie movie)
    {
        movieDbContext.Movies.Add(movie);
        movieDbContext.SaveChanges();
    }

    public void RateMovie(Guid movieId, int stars)
    {
        movieDbContext.Ratings.Add(new Rating { MovieId = movieId, Stars = stars });
        movieDbContext.SaveChanges();
    }

    public ICollection<Rating> GetRatingsForMovie(Guid movieId)
    {
        return movieDbContext.Ratings.Where(r => r.MovieId == movieId).ToList();
    }
}