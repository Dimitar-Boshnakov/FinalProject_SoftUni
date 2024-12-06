using BookingApp.Data;
using BookingApp.Web.Models;
using BookingApp.Web.ViewModels.Models.HomeViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace BookingApp.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly BookingDbContext _context;

        public HomeController(BookingDbContext context)
        {
            _context = context;
        }

        public IActionResult Index(string location, decimal? minPrice, decimal? maxPrice, bool? isAvailable)
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

            var propertiesViewModel = properties
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


            return View(propertiesViewModel);
        }
    

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
