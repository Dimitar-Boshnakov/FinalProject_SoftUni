using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingApp.Data.Models
{
    using static BookingApp.Common.EntityValidations;
    public class Amenity
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required]
        [MaxLength(AmenityValidation.AmenityNameMaxLength)]
        public string AmenityName { get; set; } = null!;

        public virtual ICollection<PropertyAmenity> PropertiesAmenities { get; set; } = new HashSet<PropertyAmenity>();
    }
}
