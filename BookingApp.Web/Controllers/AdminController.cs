using BookingApp.Data.Models;
using BookingApp.Services.Data.Interfaces;
using BookingApp.Web.ViewModels.Models.Users;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BookingApp.Web.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : BaseController
    {
        private readonly IAdminService _adminService;

        public AdminController(IAdminService adminService)
        {
            _adminService = adminService;
        }

        public IActionResult Dashboard()
        {
            return View("~/Views/Admin/Dashboard.cshtml");
        }

        public async Task<IActionResult> ManageProperties()
        {
            var properties = await _adminService.GetAllPropertiesAsync();
            return View(properties);
        }

        public async Task<IActionResult> ManageBookings()
        {
            var bookings = await _adminService.GetAllBookingsAsync();
            return View(bookings);
        }

        public async Task<IActionResult> ManageUsers()
        {
            var users = await _adminService.GetAllUsersAsync();
            return View(users);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteUser(Guid id)
        {
            var success = await _adminService.DeleteUserAsync(id);
            if (!success)
            {
                ModelState.AddModelError(string.Empty, "User not found or could not be deleted.");
            }

            return RedirectToAction(nameof(ManageUsers));
        }

        [HttpPost]
        public async Task<IActionResult> ChangeRole(Guid id, string role)
        {
            var success = await _adminService.ChangeUserRoleAsync(id, role);
            if (!success)
            {
                ModelState.AddModelError(string.Empty, "User not found or role change failed.");
            }

            return RedirectToAction(nameof(ManageUsers));
        }

    }
}
