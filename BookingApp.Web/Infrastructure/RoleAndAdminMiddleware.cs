using BookingApp.Data.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System.Threading.Tasks;

namespace BookingApp.Web.Infrastructure
{
    public static class RoleAndAdminMiddleware
    {
        public static async Task UseRoleSeederAsync(this IApplicationBuilder app)
        {
            using (var scope = app.ApplicationServices.CreateScope())
            {
                var services = scope.ServiceProvider;
                var roleManager = services.GetRequiredService<RoleManager<IdentityRole<Guid>>>();
                var userManager = services.GetRequiredService<UserManager<ApplicationUser>>();
                await UserAdminLogic.SeedRolesAsync(roleManager, userManager);
            }
        }
    }
}
