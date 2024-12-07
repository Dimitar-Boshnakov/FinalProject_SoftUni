using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingApp.Web.ViewModels.Models.Booking
{
    public class BookingViewModel
    {
        public Guid Id { get; set; }
        public string PropertyName { get; set; } = null!;
        public string PropertyLocation { get; set; } = null!;
        public decimal Price { get; set; }
        public DateTime ArrivalDate { get; set; }
        public DateTime LeaveDate { get; set; }
        public bool IsAvailable { get; set; } 
    }
}
