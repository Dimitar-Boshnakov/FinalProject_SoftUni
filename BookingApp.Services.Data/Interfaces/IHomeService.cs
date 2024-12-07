using BookingApp.Web.ViewModels.Models.HomeViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingApp.Services.Data.Interfaces
{
    public interface IHomeService
    {
        List<HomeIndexViewModel> GetFilteredProperties(string location, decimal? minPrice, decimal? maxPrice, bool? isAvailable);

    }
}
