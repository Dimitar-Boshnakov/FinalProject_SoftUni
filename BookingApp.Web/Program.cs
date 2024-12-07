using BookingApp.Data;
using BookingApp.Data.Models;
using BookingApp.Services.Data;
using BookingApp.Services.Data.Interfaces;
using BookingApp.Web.Infrastructure;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace BookingApp.Web
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            string connectionString = builder.Configuration.GetConnectionString("SQLServer")!;

            // Add services to the container.
            builder.Services
                .AddDbContext<BookingDbContext>(options =>
                {
                    options.UseSqlServer(connectionString);
                });

            builder.Services.AddIdentity<ApplicationUser, IdentityRole<Guid>>()
                .AddEntityFrameworkStores<BookingDbContext>()
                .AddDefaultUI()
                .AddDefaultTokenProviders();

            builder.Services.Configure<IdentityOptions>(options =>
            {
                options.Password.RequireDigit = true;
                options.Password.RequiredLength = 6;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = true;
                options.Password.RequireLowercase = true;
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
                options.Lockout.MaxFailedAccessAttempts = 5;
                options.User.RequireUniqueEmail = true;
            });

            builder.Services.AddScoped<IHomeService, HomeService>();
            builder.Services.AddScoped<IPropertyService, PropertyService>();
            builder.Services.AddRazorPages();

            builder.Services.AddControllersWithViews();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.MapRazorPages();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");


            using (var scope = app.Services.CreateScope())
            {
                var serviceProvider = scope.ServiceProvider;
                UserAdminLogic.SeedRolesAndAdminAsync(serviceProvider).GetAwaiter().GetResult();
            }

            app.Run();
        }
    }
}
