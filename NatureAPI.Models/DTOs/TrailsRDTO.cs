namespace NatureAPI.Models.DTOs;

public class TrailRDTO 
{ 
    public int Id { get; set; } 
    public string Name { get; set; } 
    public double DistanceKm { get; set; } 
    public int EstimatedTimeMinutes { get; set; } 
    public string Difficulty { get; set; } 
    public string Path { get; set; } 
    public bool IsLoop { get; set; } 
// Nested Place info 
    public PlaceDTO Place { get; set; } 
} 
public class PlaceDTO 
{ 
    public int Id { get; set; } 
    public string Name { get; set; } 
    public bool Accessible { get; set; } 
} 