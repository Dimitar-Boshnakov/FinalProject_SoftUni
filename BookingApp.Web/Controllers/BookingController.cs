using BookingApp.Data.Models;
using BookingApp.Services.Data.Interfaces;
using BookingApp.Web.ViewModels.Models.Booking;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace BookingApp.Web.Controllers
{
    [Authorize(Roles = "User")]
    public class BookingController : BaseController
    {
        private readonly IBookingService _bookingService;
        private readonly UserManager<ApplicationUser> _userManager;

        public BookingController(IBookingService bookingService, UserManager<ApplicationUser> userManager)
        {
            _bookingService = bookingService;
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {

            var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier);
            if (userIdClaim == null)
            {
                return Unauthorized();
            }

            var userId = Guid.Parse(userIdClaim.Value);

            var user = await _userManager.FindByIdAsync(userId.ToString());
            if (await _userManager.IsInRoleAsync(user, "Admin"))
            {
                return RedirectToAction("Dashboard", "Admin");
            }

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
            var userId = GetUserId();
            if (userId == null)
            {
                return Unauthorized();
            }

            var success = await _bookingService.CreateBookingAsync(propertyId, userId.Value, arrivalDate, leaveDate);
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