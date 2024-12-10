using BookingApp.Data;
using BookingApp.Services.Data.Interfaces;
using BookingApp.Web.Models;
using BookingApp.Web.ViewModels.Models.HomeViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace BookingApp.Web.Controllers
{
    public class HomeController : BaseController
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

        [Route("Error")]
        public IActionResult Error()
        {
            return RedirectToAction("Error500", "Base");
        }
    }
}
