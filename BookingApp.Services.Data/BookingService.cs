using BookingApp.Data;
using BookingApp.Data.Models;
using BookingApp.Services.Data.Interfaces;
using BookingApp.Web.ViewModels.Models.Booking;
using Microsoft.EntityFrameworkCore;
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
            var booking = await _context.Bookings
                .Include(b => b.Property)
                .FirstOrDefaultAsync(b => b.Id == bookingId);

            if (booking == null || booking.IsPaid)
                return false;

            booking.IsPaid = true;

            if (booking.Property != null)
            {
                booking.Property.IsAvailable = false;
            }

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> CreateBookingAsync(Guid propertyId, Guid userId, DateTime arrivalDate, DateTime leaveDate)
        {
            var property = await _context.Properties.FirstOrDefaultAsync(p => p.Id == propertyId && p.IsAvailable);
            if (property == null || arrivalDate >= leaveDate)
            {
                return false;
            }

            var booking = new Booking
            {
                Id = Guid.NewGuid(),
                PropertyId = propertyId,
                ArrivalDate = arrivalDate,
                LeaveDate = leaveDate,
                Property = property
            };

            //property.IsAvailable = false;

            _context.Bookings.Add(booking);
            await _context.SaveChangesAsync();

            var userBooking = new ApplicationUserBookings
            {
                ApplicationUserId = userId,
                BookingId = booking.Id
            };

            _context.UserBookings.Add(userBooking);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<IEnumerable<Booking>> GetUserBookingsAsync(Guid userId)
        {
            return await _context.UserBookings
               .Where(ub => ub.ApplicationUserId == userId)
               .Include(ub => ub.Booking)
               .ThenInclude(b => b.Property)
               .Select(ub => ub.Booking)
               .ToListAsync();
        }

        public async Task<bool> DeleteBookingAsync(Guid bookingId)
        {
            var booking = await _context.Bookings.Include(b => b.Property).FirstOrDefaultAsync(b => b.Id == bookingId);
            if (booking == null) return false;

            // Маркираме имота като свободен
            if (booking.Property != null)
            {
                booking.Property.IsAvailable = true;
            }

            // Премахваме резервацията
            _context.Bookings.Remove(booking);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<List<BookingViewModel>> GetAllBookingsAsync()
        {
            return await _context.Bookings
                .Include(b => b.Property)
                .Select(b => new BookingViewModel
                {
                    Id = b.Id,
                    PropertyName = b.Property.PropertyName,
                    ArrivalDate = b.ArrivalDate,
                    LeaveDate = b.LeaveDate,
                    IsPaid = b.IsPaid
                })
                .ToListAsync();
        }
    }
}
