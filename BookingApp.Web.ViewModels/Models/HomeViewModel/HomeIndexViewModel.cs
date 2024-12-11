
namespace BookingApp.Web.ViewModels.Models.HomeViewModel
{
    public class HomeIndexViewModel
    {
        public Guid Id { get; set; }

        public string Name { get; set; } = null!;

        public string Location { get; set; } = null!;

        public decimal Price { get; set; }

        public string Decsription { get; set; } = null!;

        public string ImgUrl { get; set; } = null!;

        public bool IsAvailable { get; set; }
    }
}