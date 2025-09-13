namespace NatureAPI.Models.Entities;

public class Amenity
{
    public int Id { get; set; }

    public string Name { get; set; }  // e.g., Restroom, Parking, Viewpoint
    
    public List<Place> Places { get; set; } 
    public List<PlaceAmenity> PlaceAmenities { get; set; } 
}
