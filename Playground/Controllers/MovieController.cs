using Microsoft.AspNetCore.Mvc;
using Playground.Entities;
using Playground.Interfaces;

namespace Playground.Controllers;

[ApiController]
[Route("movie")]
public class MovieController(IMovieRepository movieRepository) : ControllerBase
{
    [HttpGet]
    public IEnumerable<Movie> Get()
    {
        return movieRepository.GetMovies();
    }

    [HttpGet("{id}")]
    public Movie Get(Guid id)
    {
        return movieRepository.GetMovie(id);
    }

    [HttpPost]
    public IActionResult Post(Movie movie)
    {
        movieRepository.AddMovie(movie);
        return CreatedAtRoute("GetMovie", new { id = movie.Id }, movie);
    }

    [HttpPost("{id}/rate/{stars}")]
    public IActionResult Rate(Guid id, int stars)
    {
        movieRepository.RateMovie(id, stars);
        return NoContent();
    }

    [HttpGet("{id}/ratings")]
    public IEnumerable<Rating> GetRatings(Guid id)
    {
        return movieRepository.GetRatingsForMovie(id);
    }
}