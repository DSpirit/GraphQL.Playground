using Playground.Entities;

namespace Playground.Models;

public class ImdbResponse(Movie movie, ICollection<Rating> ratings)
{
    public string Title => movie.Title;
    public string Plot => movie.Plot;
    public IEnumerable<Rating> Ratings => ratings;
    public double AverageRating => ratings.Count > 0 ? ratings.Average(r => r.Stars) : 0;
}