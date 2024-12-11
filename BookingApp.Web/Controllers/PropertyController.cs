using BookingApp.Services.Data.Interfaces;
using BookingApp.Web.ViewModels.Models.Property;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace BookingApp.Web.Controllers
{
    public class PropertyController : BaseController
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
            var userId = GetUserId();
            if (userId == null)
            {
                return Unauthorized("User is not authenticated.");
            }

            var success = await _propertyService.BookPropertyAsync(id, userId.Value);

            if (!success)
            {
                return BadRequest("The property is either unavailable or does not exist.");
            }

            return RedirectToAction("Index", "Bookings");
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Add(AddPropertyViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (string.IsNullOrEmpty(userId))
            {
                return Unauthorized();
            }

            var success = await _propertyService.AddPropertyAsync(model, Guid.Parse(userId));
            if (!success)
            {
                TempData["ErrorMessage"] = "Could not add the property. Please try again.";
                return View(model);
            }

            TempData["SuccessMessage"] = "Property added successfully.";
            return RedirectToAction("MyProperties");
        }

        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (string.IsNullOrEmpty(userId))
            {
                return Unauthorized();
            }

            var model = await _propertyService.GetPropertyForEditAsync(id, Guid.Parse(userId));
            if (model == null)
            {
                return NotFound();
            }

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(EditPropertyViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (string.IsNullOrEmpty(userId))
            {
                return Unauthorized();
            }

            var success = await _propertyService.UpdatePropertyAsync(model, Guid.Parse(userId));
            if (!success)
            {
                TempData["ErrorMessage"] = "Could not update the property. Please try again.";
                return View(model);
            }

            TempData["SuccessMessage"] = "Property updated successfully.";
            return RedirectToAction("MyProperties");
        }

        [HttpPost]
        public async Task<IActionResult> Delete(Guid id)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (string.IsNullOrEmpty(userId))
            {
                return Unauthorized();
            }

            var success = await _propertyService.DeletePropertyAsync(id, Guid.Parse(userId));
            if (!success)
            {
                TempData["ErrorMessage"] = "Could not delete the property. Please try again.";
                return RedirectToAction("MyProperties");
            }

            TempData["SuccessMessage"] = "Property deleted successfully.";
            return RedirectToAction("MyProperties");
        }

        [HttpGet]
        public async Task<IActionResult> MyProperties()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (string.IsNullOrEmpty(userId))
            {
                return Unauthorized();
            }

            var properties = await _propertyService.GetUserPropertiesAsync(Guid.Parse(userId));
            return View(properties);
        }

    }
}