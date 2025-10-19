namespace NatureAPI.Models.DTOs;

public class PlaceRDTO 
{ 
    public int Id { get; set; } 
    public string Name { get; set; } 
    public string Description { get; set; } 
    public string Category { get; set; } 
    public double Latitude { get; set; } 
    public double Longitude { get; set; } 
    public int ElevationMeters { get; set; } 
    public bool Accessible { get; set; } 
    public double EntryFee { get; set; } 
    public string OpeningHours { get; set; } 
    public DateTime CreatedAt { get; set; } 
    public List<PhotoDTO> Photos { get; set; } = new List<PhotoDTO>(); 
    public List<AmenityDTO> Amenities { get; set; } = new List<AmenityDTO>(); 
    public List<TrailRDTO> Trails { get; set; } = new List<TrailRDTO>(); 
}