using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace BookingApp.Web.Controllers
{
    public class BaseController : Controller
    {
        protected Guid? GetUserId()
        {
            var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            return userIdClaim != null ? Guid.Parse(userIdClaim) : (Guid?)null;
        }

        protected bool IsUserInRole(string role)
        {
            return User.IsInRole(role);
        }

        [Route("Error/404")]
        public IActionResult Error404()
        {
            Response.StatusCode = 404;
            return View("~/Views/CustomError/Error404.cshtml");
        }

        [Route("Error/500")]
        public IActionResult Error500()
        {
            Response.StatusCode = 500;
            return View("~/Views/CustomError/Error500.cshtml");
        }
    }
}
