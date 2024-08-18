using Microsoft.EntityFrameworkCore;
using MongoDB.Bson;
using Playground.Entities;
using Playground.Interfaces;

namespace Playground.Repositories;

public class MovieRepository(MovieDbContext movieDbContext) : IMovieRepository
{
    public IEnumerable<Movie> GetMovies()
    {
        return movieDbContext.Movies;
    }

    public Movie GetMovie(Guid id)
    {
        return movieDbContext.Movies.FirstOrDefault(m => m.Id == id);
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