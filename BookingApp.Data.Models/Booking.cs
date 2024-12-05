using BookingApp.Data.Models.Enum;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookingApp.Data.Models
{
    using static BookingApp.Common.EntityValidations;

    public class Booking
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required]
        [Comment("Arrival Date")]
        public DateTime AccommodationDate { get; set; }

        [Required]
        [Comment("Leave Date")]
        public DateTime LeaveDate { get; set; }

        [Required]
        [Range((double)BookingValidation.TotalPriceMinValue, (double)BookingValidation.TotalPriceMaxValue)]
        [Comment("Total Price for all nights")]
        public decimal TotalPrice { get; set; }

        [Required]
        [Comment("whether it's cancelled or confirmed")]
        public BookingStatus BookingStatus { get; set; }

        [Required]
        public Guid UserId { get; set; }

        [ForeignKey(nameof(UserId))]
        public virtual AppUser User { get; set; } = null!;

        [Required]
        public Guid PropertyId { get; set; }

        [ForeignKey(nameof(PropertyId))]
        public virtual Property Property { get; set; } = null!;

        public virtual Payment Payment { get; set; } = null!;
    }
}