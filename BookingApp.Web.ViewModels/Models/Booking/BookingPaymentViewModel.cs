using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingApp.Web.ViewModels.Models.Booking
{
    public class BookingPaymentViewModel
    {
        public Guid BookingId { get; set; }
        public decimal Amount { get; set; }
        public DateTime Date { get; set; }
        public string PropertyName { get; set; } = null!;
        public DateTime ArrivalDate { get; set; }
        public DateTime LeaveDate { get; set; }
    }
}
