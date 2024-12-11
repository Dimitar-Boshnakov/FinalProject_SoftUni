using BookingApp.Data;
using BookingApp.Data.Models;
using BookingApp.Services.Data.Interfaces;
using BookingApp.Web.ViewModels.Models.Property;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingApp.Services.Data
{
    public class PropertyService : BaseService, IPropertyService
    {

        private readonly BookingDbContext _context;

        public PropertyService(BookingDbContext context)
        {
            _context = context;
        }

        public async Task<bool> BookPropertyAsync(Guid id, Guid userId)
        {
            var property = await _context.Properties.FirstOrDefaultAsync(p => p.Id == id);

            if (property == null || !property.IsAvailable)
            {
                return false;
            }

            property.IsAvailable = false;

            var booking = new Booking
            {
                Id = Guid.NewGuid(),
                PropertyId = property.Id,
            };

            _context.Bookings.Add(booking);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<PropertyDetailsViewModel> GetPropertyDetailsAsync(Guid id)
        {
            var property = await _context.Properties
                 .FirstOrDefaultAsync(p => p.Id == id);

            if (property == null)
            {
                throw new ArgumentException("Property not found.");
            }

            return new PropertyDetailsViewModel
            {
                Id = property.Id,
                Name = property.PropertyName,
                Description = property.Description ?? "No Description",
                Location = property.Location,
                Price = property.PricePerNight,
                IsAvailable = property.IsAvailable
            };
        }

        public async Task<List<PropertyDetailsViewModel>> GetAllPropertiesAsync()
        {
            return await _context.Properties
                .Select(p => new PropertyDetailsViewModel
                {
                    Id = p.Id,
                    Name = p.PropertyName,
                    Location = p.Location,
                    Price = p.PricePerNight,
                    IsAvailable = p.IsAvailable
                })
                .ToListAsync();
        }

        public async Task<bool> AddPropertyAsync(AddPropertyViewModel model, Guid userId)
        {
            var property = new Property
            {
                Id = Guid.NewGuid(),
                PropertyName = model.Name,
                Description = model.Description,
                Location = model.Location,
                PricePerNight = model.PricePerNight,
                ImgUrl = model.ImgUrl,
                OwnerId = userId,
                IsAvailable = true
            };

            await _context.Properties.AddAsync(property);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<EditPropertyViewModel?> GetPropertyForEditAsync(Guid propertyId, Guid userId)
        {
            var property = await _context.Properties
                .Where(p => p.Id == propertyId && p.OwnerId == userId)
                .Select(p => new EditPropertyViewModel
                {
                    Id = p.Id,
                    Name = p.PropertyName,
                    Description = p.Description,
                    Location = p.Location,
                    PricePerNight = p.PricePerNight,
                    ImgUrl = p.ImgUrl
                })
                .FirstOrDefaultAsync();

            return property;
        }

        public async Task<bool> UpdatePropertyAsync(EditPropertyViewModel model, Guid userId)
        {
            var property = await _context.Properties.FirstOrDefaultAsync(p => p.Id == model.Id && p.OwnerId == userId);

            if (property == null)
            {
                return false;
            }

            property.PropertyName = model.Name;
            property.Description = model.Description;
            property.Location = model.Location;
            property.PricePerNight = model.PricePerNight;
            property.ImgUrl = model.ImgUrl;

            _context.Properties.Update(property);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeletePropertyAsync(Guid propertyId, Guid userId)
        {
            var property = await _context.Properties.FirstOrDefaultAsync(p => p.Id == propertyId && p.OwnerId == userId);

            if (property == null)
            {
                return false;
            }

            _context.Properties.Remove(property);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<PropertyListViewModel>> GetUserPropertiesAsync(Guid userId)
        {
            return await _context.Properties
                .Where(p => p.OwnerId == userId)
                .Select(p => new PropertyListViewModel
                {
                    Id = p.Id,
                    Name = p.PropertyName,
                    Location = p.Location,
                    PricePerNight = p.PricePerNight,
                    IsAvailable = p.IsAvailable
                })
                .ToListAsync();
        }
    }

}