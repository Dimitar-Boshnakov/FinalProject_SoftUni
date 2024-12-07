using BookingApp.Data;
using BookingApp.Data.Models;
using BookingApp.Services.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingApp.Services.Data
{
    public class BookingService : BaseService, IBookingService
    {
        private readonly BookingDbContext _context;

        public BookingService(BookingDbContext context)
        {
            _context = context;
        }

        public async Task<bool> ConfirmPaymentAsync(Guid bookingId)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> CreateBookingAsync(Guid propertyId, Guid userId, DateTime arrivalDate, DateTime leaveDate)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Booking>> GetUserBookingsAsync(Guid userId)
        {
            throw new NotImplementedException();
        }
    }
}
