using Playground.Entities;

namespace Playground.Interfaces;

public interface ICinemaRepository
{
    public IEnumerable<Movie> GetMovies();
    public Movie GetMovie(Guid id);
    public void AddMovie(Movie movie);
    public void RateMovie(Guid movieId, int stars);
    public ICollection<Rating> GetRatingsForMovie(Guid movieId);
}