using System.ComponentModel.DataAnnotations;

namespace BookingApp.Data.Models
{
    public class Property
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required]
        public string PropertyName { get; set; } = null!;

        [Required]
        public string Location { get; set; } = null!;

        public string? Description { get; set; } 

        public bool IsAvailable { get; set; }

        public bool IsDeleated { get; set; }
    }
}
