using Microsoft.AspNetCore.Identity;


namespace BookingApp.Data.Models
{
    using static BookingApp.Common.EntityValidations;

    public class AppUser : IdentityUser<Guid>
    {
        public AppUser() 
        {
            this.Id = Guid.NewGuid();
        }

        [Required]
        [MaxLength(AppUserValidation.FirstNameMaxLength)]
        [Comment("User First Name")]
        public string FirstName { get; set; } = null!;

        [Required]
        [MaxLength(AppUserValidation.LastNameMaxLength)]
        [Comment("User Last Name")]
        public string LastName { get; set; } = null!;

        [Required]
        [EmailAddress]
        [Comment("User Email")]
        public string UserEmail {  get; set; } = null!;

        public virtual ICollection<Property> Properties { get; set; } = new HashSet<Property>();
    }
}
