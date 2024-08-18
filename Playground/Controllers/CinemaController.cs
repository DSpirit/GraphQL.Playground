using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using Playground.Entities;
using Playground.Interfaces;

namespace Playground.Controllers;

[ApiController]
[Route("cinema")]
public class CinemaController(
    ICinemaRepository movieRepository,
    ILogger<CinemaController> logger)
    : ControllerBase
{
    [HttpGet(Name = "GetMovies")]
    public IEnumerable<Movie> Get()
    {
        return movieRepository.GetMovies();
    }

    [HttpGet("{id}", Name = "GetMovie")]
    public Movie Get(Guid id)
    {
        return movieRepository.GetMovie(id);
    }

    [HttpPost(Name = "AddMovie")]
    public IActionResult Post(Movie movie)
    {
        movieRepository.AddMovie(movie);
        return CreatedAtRoute("GetMovie", new { id = movie.Id }, movie);
    }

    [HttpPost("{id}/rate/{stars}", Name = "RateMovie")]
    public IActionResult Rate(Guid id, int stars)
    {
        movieRepository.RateMovie(id, stars);
        return NoContent();
    }

    [HttpGet("{id}/ratings", Name = "GetRatingsForMovie")]
    public IEnumerable<Rating> GetRatings(Guid id)
    {
        return movieRepository.GetRatingsForMovie(id);
    }
}