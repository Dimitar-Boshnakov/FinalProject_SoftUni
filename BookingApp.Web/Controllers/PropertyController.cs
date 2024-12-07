using BookingApp.Services.Data.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BookingApp.Web.Controllers
{
    public class PropertyController : Controller
    {
        private readonly IPropertyService _propertyService;

        public PropertyController(IPropertyService propertyService)
        {
            _propertyService = propertyService;
        }

        public async Task<IActionResult> ViewDetails(Guid id)
        {
            try
            {
                var model = await _propertyService.GetPropertyDetailsAsync(id);
                return View(model);
            }
            catch (ArgumentException)
            {
                return NotFound();
            }
        }

        [Authorize]
        public async Task<IActionResult> BookProperty(Guid id)
        {
            var userId = Guid.Parse(User.FindFirst("Id")!.Value);

            var success = await _propertyService.BookPropertyAsync(id, userId);

            if (!success)
            {
                return BadRequest("The property is either unavailable or does not exist.");
            }

            return RedirectToAction("Index", "Bookings");
        }
    }
}
