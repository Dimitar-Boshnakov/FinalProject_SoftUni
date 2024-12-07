using BookingApp.Data;
using BookingApp.Services.Data;
using BookingApp.Services.Data.Interfaces;
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



            builder.Services.AddScoped<IHomeService, HomeService>();

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

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
