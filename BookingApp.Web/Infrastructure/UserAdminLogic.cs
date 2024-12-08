using BookingApp.Data.Models;
using Microsoft.AspNetCore.Identity;

namespace BookingApp.Web.Infrastructure
{
    public class UserAdminLogic
    {
        public static async Task SeedRolesAsync(RoleManager<IdentityRole<Guid>> roleManager, UserManager<ApplicationUser> userManager)
        {
            string[] roleNames = { "Admin", "User" };
            foreach (var roleName in roleNames)
            {
                if (!await roleManager.RoleExistsAsync(roleName))
                {
                    await roleManager.CreateAsync(new IdentityRole<Guid>(roleName));
                }
            }

            var adminEmail = "admin@domain.com";
            var adminUser = await userManager.FindByEmailAsync(adminEmail);
            if (adminUser == null)
            {
                var user = new ApplicationUser
                {
                    UserName = adminEmail,
                    Email = adminEmail,
                    EmailConfirmed = true
                };

                var result = await userManager.CreateAsync(user, "Admin123!");
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(user, "Admin");
                }
            }

            var allUsers = userManager.Users.ToList();

            foreach (var user in allUsers)
            {
                var roles = await userManager.GetRolesAsync(user);
                if (roles.Count == 0) 
                {
                    await userManager.AddToRoleAsync(user, "User");
                }
            }

            foreach (var user in allUsers)
            {
                var roles = await userManager.GetRolesAsync(user);
                if (roles.Count == 0) 
                {
                    await userManager.AddToRoleAsync(user, "User");
                    Console.WriteLine($"Role 'User' added to {user.Email}");
                }
            }
        }
    }
}
