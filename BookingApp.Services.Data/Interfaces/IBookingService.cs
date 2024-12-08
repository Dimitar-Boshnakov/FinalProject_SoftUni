using BookingApp.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingApp.Services.Data.Interfaces
{
    public interface IBookingService
    {
        Task<bool> CreateBookingAsync(Guid propertyId, Guid userId, DateTime arrivalDate, DateTime leaveDate);
        Task<IEnumerable<Booking>> GetUserBookingsAsync(Guid userId);
        Task<bool> ConfirmPaymentAsync(Guid bookingId);

        Task<bool> DeleteBookingAsync(Guid bookingId);
    }
}
