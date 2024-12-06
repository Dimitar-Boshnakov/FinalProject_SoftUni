using BookingApp.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace BookingApp.Data
{
    public class BookingDbContext : DbContext 
    {
        public BookingDbContext()
        {

        }

        public BookingDbContext(DbContextOptions options)
            : base(options) 
        {

        }

        public virtual DbSet<Property> Properties { get; set; } = null!;

        public virtual DbSet<Booking> Bookings { get; set; } = null!;

        public virtual DbSet<Payment> Payments { get; set; } = null!;
    }
}
