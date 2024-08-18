using GraphQL;
using Playground.Entities;
using Playground.Interfaces;
using Playground.Models;

namespace Playground.Schemas;

public class GraphQLSchema
{
    public static IEnumerable<Movie> Movies([FromServices] ICinemaRepository repository)
    {
        return repository.GetMovies();
    }

    public static Movie Movie([FromServices] IMovieRepository repository, Guid movieId)
    {
        var movie = repository.GetMovie(movieId);
        movie.Ratings = repository.GetRatingsForMovie(movieId);

        return movie;
    }

    public static IEnumerable<ImdbResponse> Records([FromServices] IMovieRepository repository)
    {
        var movies = repository.GetMovies();
        return movies.Select(m => new ImdbResponse(m, repository.GetRatingsForMovie(m.Id)));
    }

    public static ImdbResponse Record([FromServices] IMovieRepository repository, Guid movieId)
    {
        var movie = repository.GetMovie(movieId);
        return new ImdbResponse(movie, repository.GetRatingsForMovie(movieId));
    }
}