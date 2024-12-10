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
    public class ApplicationUserConfiguration : IEntityTypeConfiguration<ApplicationUser>
    {
        public void Configure(EntityTypeBuilder<ApplicationUser> builder) 
        {
            builder.HasData(new ApplicationUser
            {
                Id = Guid.Parse("ea8aa96e-339b-46cf-b8d7-2c944dc2c66d"),
                UserName = "owner1",
                Email = "owner1@example.com",
                NormalizedUserName = "OWNER1",
                NormalizedEmail = "OWNER1@EXAMPLE.COM",
                PasswordHash = "Owner1" 
            },
            new ApplicationUser
            {
                Id = Guid.Parse("5116b6a2-6109-430c-9529-b876b565134b"),
                UserName = "owner2",
                Email = "owner2@example.com",
                NormalizedUserName = "OWNER2",
                NormalizedEmail = "OWNER2@EXAMPLE.COM",
                PasswordHash = "Owner2"
            });

        }
    }
}
