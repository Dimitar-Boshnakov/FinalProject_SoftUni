using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingApp.Data.Models
{
    public class Booking
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required]
        public DateTime ArrivalDate { get; set; }

        [Required]
        public DateTime LeaveDate { get; set; }

        public bool IsPaid { get; set; }

        [Required]
        public Guid PropertyId { get; set; }

        [ForeignKey(nameof(PropertyId))]
        public virtual Property Property { get; set; } = null!;

        public virtual Payment Payment { get; set; } = null!;

        public virtual ICollection<ApplicationUserBookings> BookingApplicationUsers { get; set; }
            = new HashSet<ApplicationUserBookings>();
    }
}
