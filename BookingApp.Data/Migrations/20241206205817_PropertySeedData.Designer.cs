﻿// <auto-generated />
using System;
using BookingApp.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BookingApp.Data.Migrations
{
    [DbContext(typeof(BookingDbContext))]
    [Migration("20241206205817_PropertySeedData")]
    partial class PropertySeedData
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("BookingApp.Data.Models.Booking", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("ArrivalDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("LeaveDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("PropertyId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("PropertyId");

                    b.ToTable("Bookings");
                });

            modelBuilder.Entity("BookingApp.Data.Models.Payment", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("BookingId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("PropertyId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("TotalPrice")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("BookingId")
                        .IsUnique();

                    b.HasIndex("PropertyId");

                    b.ToTable("Payments");
                });

            modelBuilder.Entity("BookingApp.Data.Models.Property", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("ImgUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsAvailable")
                        .HasColumnType("bit");

                    b.Property<bool>("IsDeleated")
                        .HasColumnType("bit");

                    b.Property<string>("Location")
                        .IsRequired()
                        .HasMaxLength(80)
                        .HasColumnType("nvarchar(80)");

                    b.Property<decimal>("PricePerNight")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("PropertyName")
                        .IsRequired()
                        .HasMaxLength(80)
                        .HasColumnType("nvarchar(80)");

                    b.HasKey("Id");

                    b.ToTable("Properties");

                    b.HasData(
                        new
                        {
                            Id = new Guid("c2e4bf18-a6b5-4424-b368-cfe8b45aa5d1"),
                            Description = "A luxurious villa with a private pool and stunning sea views.",
                            ImgUrl = "/images/villa-sea.jpg",
                            IsAvailable = true,
                            IsDeleated = false,
                            Location = "Bulgaria, Varna",
                            PricePerNight = 350.00m,
                            PropertyName = "Luxury Villa by the Sea"
                        },
                        new
                        {
                            Id = new Guid("b03a3798-212c-4aa0-ac8a-5ea34d5db236"),
                            Description = "Cozy mountain cabin perfect for skiing season or peaceful summer retreat.",
                            ImgUrl = "/images/mountain-cabin.jpg",
                            IsAvailable = true,
                            IsDeleated = false,
                            Location = "Bulgaria, Bansko",
                            PricePerNight = 120.00m,
                            PropertyName = "Mountain Retreat"
                        },
                        new
                        {
                            Id = new Guid("6993e893-bb1d-4b77-83c8-6d3d5bc86059"),
                            Description = "Modern apartment in the heart of Sofia, close to all major attractions.",
                            ImgUrl = "/images/sofia-apartment.jpg",
                            IsAvailable = false,
                            IsDeleated = false,
                            Location = "Bulgaria, Sofia",
                            PricePerNight = 80.00m,
                            PropertyName = "City Center Apartment"
                        },
                        new
                        {
                            Id = new Guid("c41f5bd1-3d52-4689-8dcf-9b32a84a83cf"),
                            Description = "A luxurious resort with direct beach access and all-inclusive amenities.",
                            ImgUrl = "/images/beachfront-resort.jpg",
                            IsAvailable = true,
                            IsDeleated = false,
                            Location = "Bulgaria, Sunny Beach",
                            PricePerNight = 250.00m,
                            PropertyName = "Beachfront Resort"
                        },
                        new
                        {
                            Id = new Guid("96831210-14c2-4ed3-bc21-22272d58ba51"),
                            Description = "Charming house surrounded by nature, ideal for a quiet getaway.",
                            ImgUrl = "/images/countryside-house.jpg",
                            IsAvailable = true,
                            IsDeleated = false,
                            Location = "Bulgaria, Plovdiv",
                            PricePerNight = 90.00m,
                            PropertyName = "Cozy Countryside House"
                        });
                });

            modelBuilder.Entity("BookingApp.Data.Models.Booking", b =>
                {
                    b.HasOne("BookingApp.Data.Models.Property", "Property")
                        .WithMany("Bookings")
                        .HasForeignKey("PropertyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Property");
                });

            modelBuilder.Entity("BookingApp.Data.Models.Payment", b =>
                {
                    b.HasOne("BookingApp.Data.Models.Booking", "Booking")
                        .WithOne("Payment")
                        .HasForeignKey("BookingApp.Data.Models.Payment", "BookingId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BookingApp.Data.Models.Property", "Property")
                        .WithMany("Payments")
                        .HasForeignKey("PropertyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Booking");

                    b.Navigation("Property");
                });

            modelBuilder.Entity("BookingApp.Data.Models.Booking", b =>
                {
                    b.Navigation("Payment")
                        .IsRequired();
                });

            modelBuilder.Entity("BookingApp.Data.Models.Property", b =>
                {
                    b.Navigation("Bookings");

                    b.Navigation("Payments");
                });
#pragma warning restore 612, 618
        }
    }
}
