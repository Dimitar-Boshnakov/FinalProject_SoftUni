using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static BookingApp.Common.EntityValidation;

namespace BookingApp.Data.Models
{
    public class Property
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required]
        [MaxLength(PropertyValidation.PropertyNameMaxLength)]
        public string PropertyName { get; set; } = null!;

        [Required]
        [MaxLength(PropertyValidation.LocationMaxLength)]
        public string Location { get; set; } = null!;

        [Required]
        [Range((double)PropertyValidation.PricePerNightMinValue, (double)PropertyValidation.PricePerNightMaxValue)]
        public decimal PricePerNight { get; set; }

        [Required]
        public bool IsAvailable { get; set; } = true;

        [MaxLength(PropertyValidation.DescriptionMaxLength)]
        public string? Description { get; set; }

        public string? ImgUrl { get; set; }

        [Required]
        public Guid OwnerId { get; set; }

        [ForeignKey(nameof(OwnerId))]
        public ApplicationUser Owner { get; set; } = null!;

        public bool IsDeleated { get; set; } = false;

        public virtual ICollection<Booking> Bookings { get; set; } = new HashSet<Booking>();

        public virtual ICollection<Payment> Payments { get; set; } = new HashSet<Payment>();    
    }
}
