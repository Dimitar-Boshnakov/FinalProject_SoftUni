using BookingApp.Services.Data.Interfaces;
using BookingApp.Web.ViewModels.Models.Booking;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace BookingApp.Web.Controllers
{
    [Authorize(Roles = "User")]
    public class BookingController : Controller
    {
        private readonly IBookingService _bookingService;

        public BookingController(IBookingService bookingService)
        {
            _bookingService = bookingService;
        }

        public async Task<IActionResult> Index()
        {

            var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier); 
            if (userIdClaim == null)
            {
                return Unauthorized();
            }

            var userId = Guid.Parse(userIdClaim.Value);
            var bookings = await _bookingService.GetUserBookingsAsync(userId);

            var bookingViewModels = bookings.Select(b => new BookingViewModel
            {
                Id = b.Id,
                PropertyName = b.Property.PropertyName,
                PropertyLocation = b.Property.Location,
                Price = b.Property.PricePerNight * (b.LeaveDate - b.ArrivalDate).Days,
                ArrivalDate = b.ArrivalDate,
                LeaveDate = b.LeaveDate,
                IsAvailable = b.Property.IsAvailable
            });

            return View(bookingViewModels);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Guid propertyId, DateTime arrivalDate, DateTime leaveDate)
        {
            var userId = Guid.Parse(User.FindFirst(ClaimTypes.NameIdentifier)!.Value);

            var success = await _bookingService.CreateBookingAsync(propertyId, userId, arrivalDate, leaveDate);
            if (!success)
            {
                ModelState.AddModelError(string.Empty, "Could not create booking.");
                return RedirectToAction("Index", "Property");
            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> ConfirmPayment(Guid id)
        {
            var success = await _bookingService.ConfirmPaymentAsync(id);
            if (!success)
            {
                ModelState.AddModelError(string.Empty, "Could not confirm the payment. Please try again.");
            }

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Create(Guid propertyId)
        {
            ViewBag.PropertyId = propertyId; 
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> DeleteBooking(Guid id)
        {
            var success = await _bookingService.DeleteBookingAsync(id);
            if (!success)
            {
                ModelState.AddModelError(string.Empty, "Could not delete the booking. Please try again.");
            }

            return RedirectToAction(nameof(Index));
        }

    }
}
