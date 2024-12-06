using System.ComponentModel.DataAnnotations;

namespace BookingApp.Data.Models
{
    public class Property
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required]
        public string PropertyName { get; set; } = null!;

        [Required]
        public string Location { get; set; } = null!;

        [Required]
        public decimal PricePerNight { get; set; }

        [Required]
        public bool IsAvailable { get; set; }

        public string? Description { get; set; }

        public string? ImgUrl { get; set; }

        public bool IsDeleated { get; set; }

        public virtual ICollection<Booking> Bookings { get; set; } = new HashSet<Booking>();

        public virtual ICollection<Payment> Payments { get; set; } = new HashSet<Payment>();    
    }
}
