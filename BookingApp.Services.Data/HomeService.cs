using BookingApp.Data;
using BookingApp.Services.Data.Interfaces;
using BookingApp.Web.ViewModels.Models.HomeViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingApp.Services.Data
{
    public class HomeService : BaseService, IHomeService
    {
        private readonly BookingDbContext _context;

        public HomeService(BookingDbContext context)
        {
            _context = context;
        }


        public List<HomeIndexViewModel> GetFilteredProperties(string location, decimal? minPrice, decimal? maxPrice, bool? isAvailable)
        {
            var properties = _context.Properties.AsQueryable();

            if (!string.IsNullOrEmpty(location))
            {
                properties = properties.Where(p => p.Location.Contains(location));
            }

            if (minPrice.HasValue)
            {
                properties = properties.Where(p => p.PricePerNight >= minPrice.Value);
            }

            if (maxPrice.HasValue)
            {
                properties = properties.Where(p => p.PricePerNight <= maxPrice.Value);
            }

            if (isAvailable.HasValue)
            {
                properties = properties.Where(p => p.IsAvailable == isAvailable.Value);
            }

            return properties
                .Select(p => new HomeIndexViewModel
                {
                    Id = p.Id,
                    Name = p.PropertyName,
                    Location = p.Location,
                    Price = p.PricePerNight,
                    Decsription = p.Description ?? "No description available",
                    ImgUrl = p.ImgUrl ?? "/images/default-image.jpg",
                    IsAvailable = p.IsAvailable
                })
                .ToList();
        }
    }
}
