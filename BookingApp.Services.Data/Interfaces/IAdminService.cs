using BookingApp.Web.ViewModels.Models.Booking;
using BookingApp.Web.ViewModels.Models.Property;
using BookingApp.Web.ViewModels.Models.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingApp.Services.Data.Interfaces
{
    public interface IAdminService
    {
        Task<List<PropertyDetailsViewModel>> GetAllPropertiesAsync();
        Task<List<BookingViewModel>> GetAllBookingsAsync();
        Task<List<UserViewModel>> GetAllUsersAsync();
        Task<bool> DeleteUserAsync(Guid userId);
        Task<bool> ChangeUserRoleAsync(Guid userId, string role);
    }
}
