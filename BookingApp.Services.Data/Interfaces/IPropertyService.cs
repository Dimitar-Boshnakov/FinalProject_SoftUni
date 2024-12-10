using BookingApp.Web.ViewModels.Models.Property;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingApp.Services.Data.Interfaces
{
    public interface IPropertyService
    {
        Task<PropertyDetailsViewModel> GetPropertyDetailsAsync(Guid id);
        Task<bool> BookPropertyAsync(Guid id, Guid userId);
        Task<List<PropertyDetailsViewModel>> GetAllPropertiesAsync();


       
    }
}
