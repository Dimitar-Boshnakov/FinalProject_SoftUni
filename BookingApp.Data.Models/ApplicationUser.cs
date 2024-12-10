using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingApp.Data.Models
{
    public class ApplicationUser : IdentityUser<Guid>
    {
        public ApplicationUser()
        {
         
            this.Id = Guid.NewGuid();
        }

        public virtual ICollection<ApplicationUserBookings> ApplicationUserBookings { get; set; }
           = new HashSet<ApplicationUserBookings>();

        public virtual ICollection<Property> Properties { get; set; } = new HashSet<Property>();
    }
}
