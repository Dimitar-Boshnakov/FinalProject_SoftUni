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

        Task<bool> AddPropertyAsync(AddPropertyViewModel model, Guid userId);
        Task<EditPropertyViewModel?> GetPropertyForEditAsync(Guid propertyId, Guid userId);
        Task<bool> UpdatePropertyAsync(EditPropertyViewModel model, Guid userId);
        Task<bool> DeletePropertyAsync(Guid propertyId, Guid userId);
        Task<IEnumerable<PropertyListViewModel>> GetUserPropertiesAsync(Guid userId);
    }
}
