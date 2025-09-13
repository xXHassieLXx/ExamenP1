using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace NatureAPI.Models.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Amenity",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Amenity", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Place",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Category = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Latitude = table.Column<double>(type: "float", nullable: false),
                    Longitude = table.Column<double>(type: "float", nullable: false),
                    ElevationMeters = table.Column<int>(type: "int", nullable: false),
                    Accessible = table.Column<bool>(type: "bit", nullable: false),
                    EntryFee = table.Column<double>(type: "float", nullable: false),
                    OpeningHours = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Place", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AmenityPlace",
                columns: table => new
                {
                    AmenitiesId = table.Column<int>(type: "int", nullable: false),
                    PlacesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AmenityPlace", x => new { x.AmenitiesId, x.PlacesId });
                    table.ForeignKey(
                        name: "FK_AmenityPlace_Amenity_AmenitiesId",
                        column: x => x.AmenitiesId,
                        principalTable: "Amenity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AmenityPlace_Place_PlacesId",
                        column: x => x.PlacesId,
                        principalTable: "Place",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Photo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PlaceId = table.Column<int>(type: "int", nullable: false),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Photo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Photo_Place_PlaceId",
                        column: x => x.PlaceId,
                        principalTable: "Place",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PlaceAmenity",
                columns: table => new
                {
                    PlaceId = table.Column<int>(type: "int", nullable: false),
                    AmenityId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlaceAmenity", x => new { x.PlaceId, x.AmenityId });
                    table.ForeignKey(
                        name: "FK_PlaceAmenity_Amenity_AmenityId",
                        column: x => x.AmenityId,
                        principalTable: "Amenity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PlaceAmenity_Place_PlaceId",
                        column: x => x.PlaceId,
                        principalTable: "Place",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Review",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PlaceId = table.Column<int>(type: "int", nullable: false),
                    Author = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Rating = table.Column<int>(type: "int", nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Review", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Review_Place_PlaceId",
                        column: x => x.PlaceId,
                        principalTable: "Place",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Trail",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PlaceId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DistanceKm = table.Column<double>(type: "float", nullable: false),
                    EstimatedTimeMinutes = table.Column<int>(type: "int", nullable: false),
                    Difficulty = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Path = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsLoop = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trail", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Trail_Place_PlaceId",
                        column: x => x.PlaceId,
                        principalTable: "Place",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Amenity",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Restroom" },
                    { 2, "Parking" },
                    { 3, "Restaurant" },
                    { 4, "Viewpoint" },
                    { 5, "Camping Area" }
                });

            migrationBuilder.InsertData(
                table: "Place",
                columns: new[] { "Id", "Accessible", "Category", "CreatedAt", "Description", "ElevationMeters", "EntryFee", "Latitude", "Longitude", "Name", "OpeningHours" },
                values: new object[,]
                {
                    { 1, true, "Nature", new DateTime(2025, 9, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "A beautiful natural swimming hole with crystal-clear water in the heart of Quintana Roo.", 5, 100.0, 20.582100000000001, -87.121499999999997, "Cenote Azul", "08:00 - 17:00" },
                    { 2, true, "Historical", new DateTime(2025, 9, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "Historic pre-Hispanic pyramids near Mexico City, a must-see archaeological site.", 2300, 85.0, 19.692499999999999, -98.843800000000002, "Teotihuacan Pyramids", "09:00 - 17:00" },
                    { 3, true, "Nature", new DateTime(2025, 9, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "Famous rock formations that resemble waterfalls, with natural mineral pools in Oaxaca.", 1800, 50.0, 16.873200000000001, -96.450000000000003, "Hierve el Agua", "07:00 - 18:00" }
                });

            migrationBuilder.InsertData(
                table: "Photo",
                columns: new[] { "Id", "PlaceId", "Url" },
                values: new object[,]
                {
                    { 1, 1, "https://rivieramaya.mx/fotos/2020/11/cenote-azul-tulum.jpg" },
                    { 2, 1, "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQG1YpDTVj2MYA94FYZETCnZa8yxQ_AXyZxBA&s" },
                    { 3, 2, "https://encrypted-tbn0.gstatic.com/licensed-image?q=tbn:ANd9GcTCAIwPvRenbX3NFdS_xlKhrvMBSVwYAp52-PQvZxjkB6uRww6uoLtL99Lc52PRxvt3hnEu29lcIP_PjCFu5zWBMK-pcmsutvBm2-NTDw" },
                    { 4, 2, "https://lh3.googleusercontent.com/gps-cs-s/AC9h4nqaEJgVpFFh6K9n69psf0kbOmizOGaZt0t4AxxCkOGfpnwmTecctwPdwOniRWUvdDx5aAELs1cyJpOGiyrTTJUYwTWP5ise_nVlLV3sMnGoG4wJzby7MI2-mZJu6oIY6UNbpvEy8w=w1080-h624-n-k-no" },
                    { 5, 3, "https://lh3.googleusercontent.com/gps-cs-s/AC9h4npPG6jc703Ex8VKyyehRbShbUyGxv17nadJNJ46DPZMtagDFKl2h3Mg_co6_fVn70WnI00afnBFKNRGkdh213L5DCj-sC5xYz75fWx3awET6jTcyBRi9b7Pscv3hZagrvUgOs5M=w135-h156-n-k-no" },
                    { 6, 3, "https://img.freepik.com/premium-vector/boiling-water-red-pot-cooking-pan-stove-with-water-steam-vector-illustration_163786-921.jpg?semt=ais_hybrid&w=740&q=80" }
                });

            migrationBuilder.InsertData(
                table: "PlaceAmenity",
                columns: new[] { "AmenityId", "PlaceId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 1 },
                    { 4, 1 },
                    { 1, 2 },
                    { 2, 2 },
                    { 3, 2 },
                    { 1, 3 },
                    { 4, 3 },
                    { 5, 3 }
                });

            migrationBuilder.InsertData(
                table: "Trail",
                columns: new[] { "Id", "Difficulty", "DistanceKm", "EstimatedTimeMinutes", "IsLoop", "Name", "Path", "PlaceId" },
                values: new object[,]
                {
                    { 1, "Easy", 2.5, 60, true, "Cenote Azul Loop", "encoded_path_1", 1 },
                    { 2, "Moderate", 3.2000000000000002, 90, false, "Riverside Trail", "encoded_path_2", 1 },
                    { 3, "Easy", 1.5, 45, true, "Pyramid Base Walk", "encoded_path_3", 2 },
                    { 4, "Moderate", 2.7999999999999998, 70, false, "Avenue of the Dead Walk", "encoded_path_4", 2 },
                    { 5, "Moderate", 1.8, 50, true, "Upper Falls Trail", "encoded_path_5", 3 },
                    { 6, "Easy", 2.2999999999999998, 65, false, "Mineral Pools Trail", "encoded_path_6", 3 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AmenityPlace_PlacesId",
                table: "AmenityPlace",
                column: "PlacesId");

            migrationBuilder.CreateIndex(
                name: "IX_Photo_PlaceId",
                table: "Photo",
                column: "PlaceId");

            migrationBuilder.CreateIndex(
                name: "IX_PlaceAmenity_AmenityId",
                table: "PlaceAmenity",
                column: "AmenityId");

            migrationBuilder.CreateIndex(
                name: "IX_Review_PlaceId",
                table: "Review",
                column: "PlaceId");

            migrationBuilder.CreateIndex(
                name: "IX_Trail_PlaceId",
                table: "Trail",
                column: "PlaceId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AmenityPlace");

            migrationBuilder.DropTable(
                name: "Photo");

            migrationBuilder.DropTable(
                name: "PlaceAmenity");

            migrationBuilder.DropTable(
                name: "Review");

            migrationBuilder.DropTable(
                name: "Trail");

            migrationBuilder.DropTable(
                name: "Amenity");

            migrationBuilder.DropTable(
                name: "Place");
        }
    }
}
