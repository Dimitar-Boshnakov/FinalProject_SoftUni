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

            // Създаване на административен потребител, ако не съществува
            var adminEmail = "admin@domain.com";
            var adminUser = await userManager.FindByEmailAsync(adminEmail);
            if (adminUser == null)
            {
                var user = new ApplicationUser
                {
                    UserName = adminEmail,
                    Email = adminEmail,
                    EmailConfirmed = true,
                    SecurityStamp = Guid.NewGuid().ToString() // Увери се, че SecurityStamp е зададен
                };

                var result = await userManager.CreateAsync(user, "Admin123!");
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(user, "Admin");
                }
            }

            // Добавяне на роля "User" към всички потребители, които нямат роли
            var allUsers = userManager.Users.ToList();
            foreach (var user in allUsers)
            {
                // Проверка дали SecurityStamp е зададен
                if (string.IsNullOrEmpty(user.SecurityStamp))
                {
                    user.SecurityStamp = Guid.NewGuid().ToString();
                    await userManager.UpdateAsync(user);
                }

                // Проверка дали потребителят има роля, ако не - добавяне на роля "User"
                var roles = await userManager.GetRolesAsync(user);
                if (roles.Count == 0)
                {
                    await userManager.AddToRoleAsync(user, "User");
                }
            }
        }
    }
}
