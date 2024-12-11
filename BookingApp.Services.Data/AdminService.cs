using BookingApp.Data.Models;
using BookingApp.Services.Data.Interfaces;
using BookingApp.Web.ViewModels.Models.Booking;
using BookingApp.Web.ViewModels.Models.Property;
using BookingApp.Web.ViewModels.Models.Users;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingApp.Services.Data
{
    public class AdminService : BaseService, IAdminService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole<Guid>> _roleManager;
        private readonly IPropertyService _propertyService;
        private readonly IBookingService _bookingService;

        public AdminService(
            UserManager<ApplicationUser> userManager,
            RoleManager<IdentityRole<Guid>> roleManager,
            IPropertyService propertyService,
            IBookingService bookingService)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _propertyService = propertyService;
            _bookingService = bookingService;
        }

        public async Task<bool> ChangeUserRoleAsync(Guid userId, string role)
        {
            var user = await _userManager.FindByIdAsync(userId.ToString());
            if (user == null)
                return false;

            var currentRoles = await _userManager.GetRolesAsync(user);
            await _userManager.RemoveFromRolesAsync(user, currentRoles);
            await _userManager.AddToRoleAsync(user, role);
            return true;
        }

        public async Task<bool> DeleteUserAsync(Guid userId)
        {
            var user = await _userManager.FindByIdAsync(userId.ToString());
            if (user == null)
                return false;

            var result = await _userManager.DeleteAsync(user);
            return result.Succeeded;
        }

        public async Task<List<BookingViewModel>> GetAllBookingsAsync()
        {
            return await _bookingService.GetAllBookingsAsync();
        }

        public async Task<List<PropertyDetailsViewModel>> GetAllPropertiesAsync()
        {
            return await _propertyService.GetAllPropertiesAsync();
        }

        public async Task<List<UserViewModel>> GetAllUsersAsync()
        {
            return _userManager.Users.Select(u => new UserViewModel
            {
                Id = u.Id,
                UserName = u.UserName,
                Email = u.Email
            }).ToList();
        }
    }
}