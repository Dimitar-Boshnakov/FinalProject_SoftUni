using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookingApp.Data.Models
{
    using static BookingApp.Common.EntityValidations;
    public class Property
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required]
        [MaxLength(PropertyValidation.PropertyNameMaxLength)]
        [Comment("PropertyName")]
        public string PropertyName { get; set; } = null!;

        [Required]
        [MaxLength(PropertyValidation.LocationMaxLength)]
        [Comment("Exact address of property")]
        public string Locations { get; set; } = null!;

        [MaxLength(PropertyValidation.DescriptionMaxLength)]
         public string? Description { get; set; }

        [Required]
        public Guid UserId { get; set; }

        [ForeignKey(nameof(UserId))]
        public virtual AppUser User { get; set; } = null!;

        [Required]
        [Range((double)(PropertyValidation.PricePerNigthMinValue),(double)(PropertyValidation.PricePerNightMaxValue) )]
        [Comment("Price per Night")]
        public decimal PricePerNight { get; set; }

        [Required]
        [Range(PropertyValidation.MaxGuestsMinValue, PropertyValidation.MaxGuestsMaxValue)]
        [Comment("Property Capacity")]
        public int MaxGuests { get; set; }

        public string? ImgUrl { get; set; }

        [Required]
        public bool IsDeleted { get; set; } = false;

        public virtual ICollection<Booking> Bookings { get; set; } = new HashSet<Booking>();
        public virtual ICollection<PropertyAmenity> PropertiesAmenities { get; set; } = new HashSet<PropertyAmenity>();
    }
}
