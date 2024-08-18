using System.ComponentModel.DataAnnotations;

namespace Playground.Entities;

public class Movie
{
    public Guid Id { get; set; }
    [MaxLength(65)]
    public string? Title { get; set; } = string.Empty;
    [MaxLength(65)]
    public string? Plot { get; set; } = string.Empty;
    public IEnumerable<Rating> Ratings { get; set; } = new List<Rating>();
}