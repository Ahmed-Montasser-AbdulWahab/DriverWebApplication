using DriverWebApplication.CustomValidators;

using System.ComponentModel.DataAnnotations;

namespace DriverWebApplication.Models
{
    public class Driver
    {
        [Required(ErrorMessage = "{0} must be provided.")]
        [Display(Name = "National Id")]
        [RegularExpression("^(2|3)[0-9]{13}$" , ErrorMessage = "{0} must be 14 digits starting with 2 or 3.")]
        public string? NationalId { get; set; }

        [Required(ErrorMessage = "Please provide your {0}")]
        [Display(Name = "First Name")]
        [StringLength(20, ErrorMessage ="Enter your {0} such that it doesn't exceed {1} letters.")]
        public string? FName { get; set; }

        [Required(ErrorMessage = "Please provide your {0}")]
        [Display(Name = "Last Name")]
        [StringLength(20, ErrorMessage = "Enter your {0} such that it doesn't exceed {1} letters.")]
        public string? LName { get; set; }


        [Required(ErrorMessage = "Please provide your {0}.")]
        [CheckAgeValidator(25, ErrorMessage = "{0} field : younger than {1} years old.")]
        [Display(Name = "Affrotto")]
        public DateTime? DateOfBirth { get; set; }

        [EmailAddress(ErrorMessage = "Enter your Email Correctly")]
        public string? Email { get; set; }

        [Display(Name = "Phone Number")]
        [Phone(ErrorMessage = "Enter your {0} correctly")]
        public string? PhoneNumber { get; set; }

        [Display(Name = "Modern Number Plates")]
        [RegularExpression("^[a-z]{2,3}-[0-9]{3,4}$", ErrorMessage ="Check the format of your plates.")]
        [NumberPlates("OldCarNumberPlates")]
        public string? ModernCarNumberPlates { get; set; }

        [Display(Name = "Old Number Plates")]
        [RegularExpression("^[0-9]+$", ErrorMessage = "Check the format of your plates.")]
        public string? OldCarNumberPlates { get; set; }

    }
}
