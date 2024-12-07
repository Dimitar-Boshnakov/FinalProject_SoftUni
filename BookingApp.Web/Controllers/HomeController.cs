using BookingApp.Data;
using BookingApp.Services.Data.Interfaces;
using BookingApp.Web.Models;
using BookingApp.Web.ViewModels.Models.HomeViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace BookingApp.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IHomeService _homeService;

        public HomeController(IHomeService homeService)
        {
            _homeService = homeService;
        }

        public IActionResult Index(string location, decimal? minPrice, decimal? maxPrice, bool? isAvailable)
        {
            var propertiesViewModel = _homeService.GetFilteredProperties(location, minPrice, maxPrice, isAvailable);
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
