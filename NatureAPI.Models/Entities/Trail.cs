namespace NatureAPI.Models.Entities;

public class Trail
{
    public int Id { get; set; }
        
    public int PlaceId { get; set; }
    public Place Place { get; set; }
        
    public string Name { get; set; }
        
    public double DistanceKm { get; set; }  
        
    public int EstimatedTimeMinutes { get; set; }  
        
    public string Difficulty { get; set; }  
        
    public string Path { get; set; }  // coordinates or encoded polyline
        
    public bool IsLoop { get; set; }  // true = loop, false = out-and-back
}