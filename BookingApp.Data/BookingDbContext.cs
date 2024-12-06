using BookingApp.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using System.Reflection;

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

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            optionsBuilder.ConfigureWarnings(warnings => warnings.Ignore(RelationalEventId.PendingModelChangesWarning));
        }

        public virtual DbSet<Property> Properties { get; set; } = null!;

        public virtual DbSet<Booking> Bookings { get; set; } = null!;

        public virtual DbSet<Payment> Payments { get; set; } = null!;



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
