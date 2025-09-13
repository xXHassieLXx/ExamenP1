using Microsoft.EntityFrameworkCore;
using NatureAPI.Models.Entities;

namespace NatureAPI.Models;

public class NatureDBContext : DbContext
{
    public DbSet<Photo> Photo { get; set; }
    public DbSet<Place> Place { get; set; }
    public DbSet<Amenity> Amenity { get; set; }
    public DbSet<PlaceAmenity> PlaceAmenity { get; set; }
    public DbSet<Review> Review { get; set; }
    public DbSet<Trail> Trail { get; set; }

    public NatureDBContext(DbContextOptions<NatureDBContext> options) : base(options)
    {
        
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<PlaceAmenity>().HasKey(p => new { p.PlaceId, p.AmenityId });

        modelBuilder.Entity<Place>().HasData(
            new Place
            {
                Id = 1, // must be static
                Name = "Cenote Azul",
                Description = "A beautiful natural swimming hole with crystal-clear water in the heart of Quintana Roo.",
                Category = "Nature",
                Latitude = 20.5821,
                Longitude = -87.1215,
                ElevationMeters = 5,
                Accessible = true,
                EntryFee = 100.0, // pesos
                OpeningHours = "08:00 - 17:00",
                CreatedAt = new DateTime(2025, 9, 7) // static date
            },
            new Place
            {
                Id = 2,
                Name = "Teotihuacan Pyramids",
                Description = "Historic pre-Hispanic pyramids near Mexico City, a must-see archaeological site.",
                Category = "Historical",
                Latitude = 19.6925,
                Longitude = -98.8438,
                ElevationMeters = 2300,
                Accessible = true,
                EntryFee = 85.0,
                OpeningHours = "09:00 - 17:00",
                CreatedAt = new DateTime(2025, 9, 7)
            },
            new Place
            {
                Id = 3,
                Name = "Hierve el Agua",
                Description = "Famous rock formations that resemble waterfalls, with natural mineral pools in Oaxaca.",
                Category = "Nature",
                Latitude = 16.8732,
                Longitude = -96.4500,
                ElevationMeters = 1800,
                Accessible = true,
                EntryFee = 50.0,
                OpeningHours = "07:00 - 18:00",
                CreatedAt = new DateTime(2025, 9, 7)
            }
        );

        //////////////////////////////////////////
        ////////////---- Trail ---- /////////////
        ////////////////////////////////////////// 
        modelBuilder.Entity<Trail>().HasData(
            // Cenote Azul trails
            new Trail { Id = 1, PlaceId = 1, Name = "Cenote Azul Loop", DistanceKm = 2.5, EstimatedTimeMinutes = 60, Difficulty = "Easy", Path = "encoded_path_1", IsLoop = true },
            new Trail { Id = 2, PlaceId = 1, Name = "Riverside Trail", DistanceKm = 3.2, EstimatedTimeMinutes = 90, Difficulty = "Moderate", Path = "encoded_path_2", IsLoop = false },

            // Teotihuacan Pyramids trails
            new Trail { Id = 3, PlaceId = 2, Name = "Pyramid Base Walk", DistanceKm = 1.5, EstimatedTimeMinutes = 45, Difficulty = "Easy", Path = "encoded_path_3", IsLoop = true },
            new Trail { Id = 4, PlaceId = 2, Name = "Avenue of the Dead Walk", DistanceKm = 2.8, EstimatedTimeMinutes = 70, Difficulty = "Moderate", Path = "encoded_path_4", IsLoop = false },

            // Hierve el Agua trails
            new Trail { Id = 5, PlaceId = 3, Name = "Upper Falls Trail", DistanceKm = 1.8, EstimatedTimeMinutes = 50, Difficulty = "Moderate", Path = "encoded_path_5", IsLoop = true },
            new Trail { Id = 6, PlaceId = 3, Name = "Mineral Pools Trail", DistanceKm = 2.3, EstimatedTimeMinutes = 65, Difficulty = "Easy", Path = "encoded_path_6", IsLoop = false });
        
        
        //////////////////////////////////////////
        ////////////---- Photos ---- /////////////
        ////////////////////////////////////////// 
        modelBuilder.Entity<Photo>().HasData(
            // Photos for Cenote Azul (PlaceId = 1)
            new Photo { Id = 1, PlaceId = 1, Url = "https://rivieramaya.mx/fotos/2020/11/cenote-azul-tulum.jpg" },
            new Photo { Id = 2, PlaceId = 1, Url = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQG1YpDTVj2MYA94FYZETCnZa8yxQ_AXyZxBA&s" },

            // Photos for Teotihuacan Pyramids (PlaceId = 2)
            new Photo { Id = 3, PlaceId = 2, Url = "https://encrypted-tbn0.gstatic.com/licensed-image?q=tbn:ANd9GcTCAIwPvRenbX3NFdS_xlKhrvMBSVwYAp52-PQvZxjkB6uRww6uoLtL99Lc52PRxvt3hnEu29lcIP_PjCFu5zWBMK-pcmsutvBm2-NTDw" },
            new Photo { Id = 4, PlaceId = 2, Url = "https://lh3.googleusercontent.com/gps-cs-s/AC9h4nqaEJgVpFFh6K9n69psf0kbOmizOGaZt0t4AxxCkOGfpnwmTecctwPdwOniRWUvdDx5aAELs1cyJpOGiyrTTJUYwTWP5ise_nVlLV3sMnGoG4wJzby7MI2-mZJu6oIY6UNbpvEy8w=w1080-h624-n-k-no" },

            // Photos for Hierve el Agua (PlaceId = 3)
            new Photo { Id = 5, PlaceId = 3, Url = "https://lh3.googleusercontent.com/gps-cs-s/AC9h4npPG6jc703Ex8VKyyehRbShbUyGxv17nadJNJ46DPZMtagDFKl2h3Mg_co6_fVn70WnI00afnBFKNRGkdh213L5DCj-sC5xYz75fWx3awET6jTcyBRi9b7Pscv3hZagrvUgOs5M=w135-h156-n-k-no" },
            new Photo { Id = 6, PlaceId = 3, Url = "https://img.freepik.com/premium-vector/boiling-water-red-pot-cooking-pan-stove-with-water-steam-vector-illustration_163786-921.jpg?semt=ais_hybrid&w=740&q=80" }
        );
        
        //////////////////////////////////////////
        ////////////---- Amenity ---- /////////////
        //////////////////////////////////////////
        modelBuilder.Entity<Amenity>().HasData(
            new Amenity { Id = 1, Name = "Restroom" },
            new Amenity { Id = 2, Name = "Parking" },
            new Amenity { Id = 3, Name = "Restaurant" },
            new Amenity { Id = 4, Name = "Viewpoint" },
            new Amenity { Id = 5, Name = "Camping Area" }
        );
        
        modelBuilder.Entity<PlaceAmenity>().HasData(
            // Cenote Azul (PlaceId = 1)
            new PlaceAmenity { PlaceId = 1, AmenityId = 1 }, // Restroom
            new PlaceAmenity { PlaceId = 1, AmenityId = 2 }, // Parking
            new PlaceAmenity { PlaceId = 1, AmenityId = 4 }, // Viewpoint

            // Teotihuacan Pyramids (PlaceId = 2)
            new PlaceAmenity { PlaceId = 2, AmenityId = 1 }, // Restroom
            new PlaceAmenity { PlaceId = 2, AmenityId = 2 }, // Parking
            new PlaceAmenity { PlaceId = 2, AmenityId = 3 }, // Restaurant

            // Hierve el Agua (PlaceId = 3)
            new PlaceAmenity { PlaceId = 3, AmenityId = 1 }, // Restroom
            new PlaceAmenity { PlaceId = 3, AmenityId = 5 }, // Camping Area
            new PlaceAmenity { PlaceId = 3, AmenityId = 4 }  // Viewpoint
        );
    }
}