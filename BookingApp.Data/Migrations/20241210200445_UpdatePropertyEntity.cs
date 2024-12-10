using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BookingApp.Data.Migrations
{
    /// <inheritdoc />
    public partial class UpdatePropertyEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<Guid>(
                name: "OwnerId",
                table: "Properties",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { new Guid("5116b6a2-6109-430c-9529-b876b565134b"), 0, "429ec1c5-0988-4b07-8638-7b07ef35ff5a", "owner2@example.com", false, false, null, "OWNER2@EXAMPLE.COM", "OWNER2", "Owner2", null, false, null, false, "owner2" },
                    { new Guid("ea8aa96e-339b-46cf-b8d7-2c944dc2c66d"), 0, "5b02ad61-d2eb-4212-aac5-e39aff636a4a", "owner1@example.com", false, false, null, "OWNER1@EXAMPLE.COM", "OWNER1", "Owner1", null, false, null, false, "owner1" }
                });

            migrationBuilder.InsertData(
                table: "Properties",
                columns: new[] { "Id", "Description", "ImgUrl", "IsAvailable", "IsDeleated", "Location", "OwnerId", "PricePerNight", "PropertyName" },
                values: new object[,]
                {
                    { new Guid("090dfc32-ebc7-4d14-b187-4df79c71a795"), "Modern apartment in the heart of Sofia, close to all major attractions.", "/images/sofia-apartment.jpg", false, false, "Bulgaria, Sofia", new Guid("ea8aa96e-339b-46cf-b8d7-2c944dc2c66d"), 80.00m, "City Center Apartment" },
                    { new Guid("3ebb12cf-a7fb-4d3f-b4ff-a381cfd64125"), "A luxurious resort with direct beach access and all-inclusive amenities.", "/images/beachfront-resort.jpg", true, false, "Bulgaria, Sunny Beach", new Guid("5116b6a2-6109-430c-9529-b876b565134b"), 250.00m, "Beachfront Resort" },
                    { new Guid("760d20d2-9370-44be-9ec8-a7cd9ddb11ca"), "Cozy mountain cabin perfect for skiing season or peaceful summer retreat.", "/images/mountain-cabin.jpg", true, false, "Bulgaria, Bansko", new Guid("ea8aa96e-339b-46cf-b8d7-2c944dc2c66d"), 120.00m, "Mountain Retreat" },
                    { new Guid("db3fd50d-d21a-4a30-aea6-bc11f614d5d0"), "Charming house surrounded by nature, ideal for a quiet getaway.", "/images/countryside-house.jpg", true, false, "Bulgaria, Plovdiv", new Guid("5116b6a2-6109-430c-9529-b876b565134b"), 90.00m, "Cozy Countryside House" },
                    { new Guid("ecfb4df6-8224-406f-b913-bf572c95c58c"), "A luxurious villa with a private pool and stunning sea views.", "/images/villa-sea.jpg", true, false, "Bulgaria, Varna", new Guid("ea8aa96e-339b-46cf-b8d7-2c944dc2c66d"), 350.00m, "Luxury Villa by the Sea" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Properties_OwnerId",
                table: "Properties",
                column: "OwnerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Properties_AspNetUsers_OwnerId",
                table: "Properties",
                column: "OwnerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Properties_AspNetUsers_OwnerId",
                table: "Properties");

            migrationBuilder.DropIndex(
                name: "IX_Properties_OwnerId",
                table: "Properties");

            migrationBuilder.DeleteData(
                table: "Properties",
                keyColumn: "Id",
                keyValue: new Guid("090dfc32-ebc7-4d14-b187-4df79c71a795"));

            migrationBuilder.DeleteData(
                table: "Properties",
                keyColumn: "Id",
                keyValue: new Guid("3ebb12cf-a7fb-4d3f-b4ff-a381cfd64125"));

            migrationBuilder.DeleteData(
                table: "Properties",
                keyColumn: "Id",
                keyValue: new Guid("760d20d2-9370-44be-9ec8-a7cd9ddb11ca"));

            migrationBuilder.DeleteData(
                table: "Properties",
                keyColumn: "Id",
                keyValue: new Guid("db3fd50d-d21a-4a30-aea6-bc11f614d5d0"));

            migrationBuilder.DeleteData(
                table: "Properties",
                keyColumn: "Id",
                keyValue: new Guid("ecfb4df6-8224-406f-b913-bf572c95c58c"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("5116b6a2-6109-430c-9529-b876b565134b"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("ea8aa96e-339b-46cf-b8d7-2c944dc2c66d"));

            migrationBuilder.DropColumn(
                name: "OwnerId",
                table: "Properties");

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
    }
}
