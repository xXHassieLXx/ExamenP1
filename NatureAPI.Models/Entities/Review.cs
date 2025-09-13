namespace NatureAPI.Models.Entities;

public class Review
{
    public int Id { get; set; }

    public int PlaceId { get; set; }  // Foreign Key to Place
    public Place Place { get; set; }

    public string Author { get; set; }

    public int Rating { get; set; }  // e.g., 1–5 stars

    public string Comment { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}