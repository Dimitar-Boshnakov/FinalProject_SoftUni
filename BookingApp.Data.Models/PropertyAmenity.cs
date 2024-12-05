using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookingApp.Data.Models
{
    [PrimaryKey(nameof(PropertyId), nameof(AmenityId))]

    public class PropertyAmenity
    {
        [Required]
        public Guid PropertyId { get; set; }

        [ForeignKey(nameof(PropertyId))]
        public virtual Property Property { get; set; } = null!;

        [Required]
        public Guid AmenityId { get; set; }

        [ForeignKey(nameof(AmenityId))]
        public virtual Amenity Amenity { get; set; } = null!;

    }
}