using BookingApp.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingApp.Data.Configuration
{
    public class PropertyConfiguration : IEntityTypeConfiguration<Property>
    {
        public void Configure(EntityTypeBuilder<Property> builder)
        {
            builder.HasData(this.GenerateProperties());
        }

        private IEnumerable<Property> GenerateProperties()
        {
            IEnumerable<Property> properties = new List<Property>() 
            {
                new Property()
                {
                    PropertyName = "Luxury Villa by the Sea",
                    Location = "Bulgaria, Varna",
                    PricePerNight = 350.00m,
                    IsAvailable = true,
                    OwnerId = Guid.Parse("ea8aa96e-339b-46cf-b8d7-2c944dc2c66d"),
                    Description = "A luxurious villa with a private pool and stunning sea views.",
                    ImgUrl = "/images/villa-sea.jpg",  
                    IsDeleated = false
                },

                new Property
                {
                    PropertyName = "Mountain Retreat",
                    Location = "Bulgaria, Bansko",
                    PricePerNight = 120.00m,
                    IsAvailable = true,
                    OwnerId = Guid.Parse("ea8aa96e-339b-46cf-b8d7-2c944dc2c66d"),
                    Description = "Cozy mountain cabin perfect for skiing season or peaceful summer retreat.",
                    ImgUrl = "/images/mountain-cabin.jpg",  
                    IsDeleated = false
                },

                new Property
                {
                    PropertyName = "City Center Apartment",
                    Location = "Bulgaria, Sofia",
                    PricePerNight = 80.00m,
                    IsAvailable = false,
                    OwnerId = Guid.Parse("ea8aa96e-339b-46cf-b8d7-2c944dc2c66d"),
                    Description = "Modern apartment in the heart of Sofia, close to all major attractions.",
                    ImgUrl = "/images/sofia-apartment.jpg",  
                    IsDeleated = false
                },

                new Property
                {
                    PropertyName = "Beachfront Resort",
                    Location = "Bulgaria, Sunny Beach",
                    PricePerNight = 250.00m,
                    IsAvailable = true,
                    OwnerId = Guid.Parse("5116b6a2-6109-430c-9529-b876b565134b"),
                    Description = "A luxurious resort with direct beach access and all-inclusive amenities.",
                    ImgUrl = "/images/beachfront-resort.jpg",  
                    IsDeleated = false
                },

                new Property
                {
                    PropertyName = "Cozy Countryside House",
                    Location = "Bulgaria, Plovdiv",
                    PricePerNight = 90.00m,
                    IsAvailable = true,
                    OwnerId = Guid.Parse("5116b6a2-6109-430c-9529-b876b565134b"),
                    Description = "Charming house surrounded by nature, ideal for a quiet getaway.",
                    ImgUrl = "/images/countryside-house.jpg",  
                    IsDeleated = false
                }
            };
            
            return properties;
        }
    }
}
