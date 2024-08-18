using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MongoDB.Bson;

namespace Playground.Entities;

public class Rating
{
    public Guid Id { get; set; }
    public Guid MovieId { get; set; }
    public int Stars { get; set; }
}