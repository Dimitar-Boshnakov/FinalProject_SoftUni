using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BookingApp.Data.Migrations
{
    /// <inheritdoc />
    public partial class PropertySeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Properties",
                columns: new[] { "Id", "Description", "ImgUrl", "IsAvailable", "IsDeleated", "Location", "PricePerNight", "PropertyName" },
                values: new object[,]
                {
                    { new Guid("6993e893-bb1d-4b77-83c8-6d3d5bc86059"), "Modern apartment in the heart of Sofia, close to all major attractions.", "/images/sofia-apartment.jpg", false, false, "Bulgaria, Sofia", 80.00m, "City Center Apartment" },
                    { new Guid("96831210-14c2-4ed3-bc21-22272d58ba51"), "Charming house surrounded by nature, ideal for a quiet getaway.", "/images/countryside-house.jpg", true, false, "Bulgaria, Plovdiv", 90.00m, "Cozy Countryside House" },
                    { new Guid("b03a3798-212c-4aa0-ac8a-5ea34d5db236"), "Cozy mountain cabin perfect for skiing season or peaceful summer retreat.", "/images/mountain-cabin.jpg", true, false, "Bulgaria, Bansko", 120.00m, "Mountain Retreat" },
                    { new Guid("c2e4bf18-a6b5-4424-b368-cfe8b45aa5d1"), "A luxurious villa with a private pool and stunning sea views.", "/images/villa-sea.jpg", true, false, "Bulgaria, Varna", 350.00m, "Luxury Villa by the Sea" },
                    { new Guid("c41f5bd1-3d52-4689-8dcf-9b32a84a83cf"), "A luxurious resort with direct beach access and all-inclusive amenities.", "/images/beachfront-resort.jpg", true, false, "Bulgaria, Sunny Beach", 250.00m, "Beachfront Resort" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Properties",
                keyColumn: "Id",
                keyValue: new Guid("6993e893-bb1d-4b77-83c8-6d3d5bc86059"));

            migrationBuilder.DeleteData(
                table: "Properties",
                keyColumn: "Id",
                keyValue: new Guid("96831210-14c2-4ed3-bc21-22272d58ba51"));

            migrationBuilder.DeleteData(
                table: "Properties",
                keyColumn: "Id",
                keyValue: new Guid("b03a3798-212c-4aa0-ac8a-5ea34d5db236"));

            migrationBuilder.DeleteData(
                table: "Properties",
                keyColumn: "Id",
                keyValue: new Guid("c2e4bf18-a6b5-4424-b368-cfe8b45aa5d1"));

            migrationBuilder.DeleteData(
                table: "Properties",
                keyColumn: "Id",
                keyValue: new Guid("c41f5bd1-3d52-4689-8dcf-9b32a84a83cf"));
        }
    }
}
