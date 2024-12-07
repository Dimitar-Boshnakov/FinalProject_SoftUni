using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BookingApp.Data.Migrations
{
    /// <inheritdoc />
    public partial class ImplementAppUserBookings : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Properties",
                keyColumn: "Id",
                keyValue: new Guid("121f37d2-34f0-4008-b040-19a314346f1f"));

            migrationBuilder.DeleteData(
                table: "Properties",
                keyColumn: "Id",
                keyValue: new Guid("9f1c9a14-7b68-4ef1-89e1-910f29debb97"));

            migrationBuilder.DeleteData(
                table: "Properties",
                keyColumn: "Id",
                keyValue: new Guid("e9b710fd-1661-4a07-ba56-042876c56109"));

            migrationBuilder.DeleteData(
                table: "Properties",
                keyColumn: "Id",
                keyValue: new Guid("f77536d7-2f48-4783-a4c2-049459921d71"));

            migrationBuilder.DeleteData(
                table: "Properties",
                keyColumn: "Id",
                keyValue: new Guid("fda258cf-5c9f-4939-9495-8853e23fa04f"));

            migrationBuilder.CreateTable(
                name: "UserBookings",
                columns: table => new
                {
                    ApplicationUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BookingId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserBookings", x => new { x.ApplicationUserId, x.BookingId });
                    table.ForeignKey(
                        name: "FK_UserBookings_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserBookings_Bookings_BookingId",
                        column: x => x.BookingId,
                        principalTable: "Bookings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_UserBookings_BookingId",
                table: "UserBookings",
                column: "BookingId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserBookings");

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

            migrationBuilder.InsertData(
                table: "Properties",
                columns: new[] { "Id", "Description", "ImgUrl", "IsAvailable", "IsDeleated", "Location", "PricePerNight", "PropertyName" },
                values: new object[,]
                {
                    { new Guid("121f37d2-34f0-4008-b040-19a314346f1f"), "Charming house surrounded by nature, ideal for a quiet getaway.", "/images/countryside-house.jpg", true, false, "Bulgaria, Plovdiv", 90.00m, "Cozy Countryside House" },
                    { new Guid("9f1c9a14-7b68-4ef1-89e1-910f29debb97"), "Modern apartment in the heart of Sofia, close to all major attractions.", "/images/sofia-apartment.jpg", false, false, "Bulgaria, Sofia", 80.00m, "City Center Apartment" },
                    { new Guid("e9b710fd-1661-4a07-ba56-042876c56109"), "A luxurious resort with direct beach access and all-inclusive amenities.", "/images/beachfront-resort.jpg", true, false, "Bulgaria, Sunny Beach", 250.00m, "Beachfront Resort" },
                    { new Guid("f77536d7-2f48-4783-a4c2-049459921d71"), "Cozy mountain cabin perfect for skiing season or peaceful summer retreat.", "/images/mountain-cabin.jpg", true, false, "Bulgaria, Bansko", 120.00m, "Mountain Retreat" },
                    { new Guid("fda258cf-5c9f-4939-9495-8853e23fa04f"), "A luxurious villa with a private pool and stunning sea views.", "/images/villa-sea.jpg", true, false, "Bulgaria, Varna", 350.00m, "Luxury Villa by the Sea" }
                });
        }
    }
}
