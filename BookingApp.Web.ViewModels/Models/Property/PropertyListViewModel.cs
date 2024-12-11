using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingApp.Web.ViewModels.Models.Property
{
    public class PropertyListViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public string Location { get; set; } = null!;
        public decimal PricePerNight { get; set; }
        public bool IsAvailable { get; set; }
    }
}
