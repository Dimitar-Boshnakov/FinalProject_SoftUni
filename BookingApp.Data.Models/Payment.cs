using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookingApp.Data.Models
{
    using static BookingApp.Common.EntityValidations;
    public class Payment
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required]
        [Range((double)PaymentValidation.AmountMinValue, (double)PaymentValidation.AmountMaxValue)]
        public decimal Amount { get; set; }

        public DateTime PaymentDate { get; set; }

        [Required]
        public Guid BookingId { get; set; }

        [ForeignKey(nameof(BookingId))]
        public virtual Booking Booking { get; set; } = null!;
    }
}