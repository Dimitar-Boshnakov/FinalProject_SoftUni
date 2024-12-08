using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BookingApp.Data.Migrations
{
    /// <inheritdoc />
    public partial class NewBookingProperty : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Properties",
                keyColumn: "Id",
                keyValue: new Guid("27dbf0c0-ca48-4eed-a7af-6e724487ef7b"));

            migrationBuilder.DeleteData(
                table: "Properties",
                keyColumn: "Id",
                keyValue: new Guid("3015b907-a721-4ced-b8e4-5dd4aa7b5c6f"));

            migrationBuilder.DeleteData(
                table: "Properties",
                keyColumn: "Id",
                keyValue: new Guid("3efd2a0d-d92e-4124-bcf6-aa656d1527e9"));

            migrationBuilder.DeleteData(
                table: "Properties",
                keyColumn: "Id",
                keyValue: new Guid("7a84ba2a-0868-4eb1-b6c3-a0cbb6dfc137"));

            migrationBuilder.DeleteData(
                table: "Properties",
                keyColumn: "Id",
                keyValue: new Guid("90c99525-72e7-4cf1-b766-baeda330fd02"));

            migrationBuilder.AddColumn<bool>(
                name: "IsPaid",
                table: "Bookings",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.InsertData(
                table: "Properties",
                columns: new[] { "Id", "Description", "ImgUrl", "IsAvailable", "IsDeleated", "Location", "PricePerNight", "PropertyName" },
                values: new object[,]
                {
                    { new Guid("2395a523-d640-41ac-a60c-c3926c683fe9"), "Modern apartment in the heart of Sofia, close to all major attractions.", "/images/sofia-apartment.jpg", false, false, "Bulgaria, Sofia", 80.00m, "City Center Apartment" },
                    { new Guid("4126760e-f136-4d64-926b-8fc183086df8"), "Charming house surrounded by nature, ideal for a quiet getaway.", "/images/countryside-house.jpg", true, false, "Bulgaria, Plovdiv", 90.00m, "Cozy Countryside House" },
                    { new Guid("5eb49b41-9b9b-4bdd-a7d8-f3f57e7329f3"), "A luxurious villa with a private pool and stunning sea views.", "/images/villa-sea.jpg", true, false, "Bulgaria, Varna", 350.00m, "Luxury Villa by the Sea" },
                    { new Guid("fa3a56b3-2426-4e53-9a0b-40640e43907e"), "A luxurious resort with direct beach access and all-inclusive amenities.", "/images/beachfront-resort.jpg", true, false, "Bulgaria, Sunny Beach", 250.00m, "Beachfront Resort" },
                    { new Guid("fa998de6-cb74-49f7-b665-47c2acac8a35"), "Cozy mountain cabin perfect for skiing season or peaceful summer retreat.", "/images/mountain-cabin.jpg", true, false, "Bulgaria, Bansko", 120.00m, "Mountain Retreat" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Properties",
                keyColumn: "Id",
                keyValue: new Guid("2395a523-d640-41ac-a60c-c3926c683fe9"));

            migrationBuilder.DeleteData(
                table: "Properties",
                keyColumn: "Id",
                keyValue: new Guid("4126760e-f136-4d64-926b-8fc183086df8"));

            migrationBuilder.DeleteData(
                table: "Properties",
                keyColumn: "Id",
                keyValue: new Guid("5eb49b41-9b9b-4bdd-a7d8-f3f57e7329f3"));

            migrationBuilder.DeleteData(
                table: "Properties",
                keyColumn: "Id",
                keyValue: new Guid("fa3a56b3-2426-4e53-9a0b-40640e43907e"));

            migrationBuilder.DeleteData(
                table: "Properties",
                keyColumn: "Id",
                keyValue: new Guid("fa998de6-cb74-49f7-b665-47c2acac8a35"));

            migrationBuilder.DropColumn(
                name: "IsPaid",
                table: "Bookings");

            migrationBuilder.InsertData(
                table: "Properties",
                columns: new[] { "Id", "Description", "ImgUrl", "IsAvailable", "IsDeleated", "Location", "PricePerNight", "PropertyName" },
                values: new object[,]
                {
                    { new Guid("27dbf0c0-ca48-4eed-a7af-6e724487ef7b"), "A luxurious villa with a private pool and stunning sea views.", "/images/villa-sea.jpg", true, false, "Bulgaria, Varna", 350.00m, "Luxury Villa by the Sea" },
                    { new Guid("3015b907-a721-4ced-b8e4-5dd4aa7b5c6f"), "A luxurious resort with direct beach access and all-inclusive amenities.", "/images/beachfront-resort.jpg", true, false, "Bulgaria, Sunny Beach", 250.00m, "Beachfront Resort" },
                    { new Guid("3efd2a0d-d92e-4124-bcf6-aa656d1527e9"), "Modern apartment in the heart of Sofia, close to all major attractions.", "/images/sofia-apartment.jpg", false, false, "Bulgaria, Sofia", 80.00m, "City Center Apartment" },
                    { new Guid("7a84ba2a-0868-4eb1-b6c3-a0cbb6dfc137"), "Cozy mountain cabin perfect for skiing season or peaceful summer retreat.", "/images/mountain-cabin.jpg", true, false, "Bulgaria, Bansko", 120.00m, "Mountain Retreat" },
                    { new Guid("90c99525-72e7-4cf1-b766-baeda330fd02"), "Charming house surrounded by nature, ideal for a quiet getaway.", "/images/countryside-house.jpg", true, false, "Bulgaria, Plovdiv", 90.00m, "Cozy Countryside House" }
                });
        }
    }
}
