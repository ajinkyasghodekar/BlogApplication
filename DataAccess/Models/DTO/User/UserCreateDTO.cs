using System.ComponentModel.DataAnnotations;

namespace BlogApplication.DataAccess.Models.DTO.User
{
    public class UserCreateDTO
    {
        [Required]
        [MaxLength(30)]
        [RegularExpression(@"^[A-Za-z\s]+$", ErrorMessage = "Enter valid name format")]
        public string Name { get; set; }

        [Required]
        [EmailAddress(ErrorMessage = "Enter valid email address")]
        public string Email { get; set; }
        public string Password { get; set; }

        [Required(ErrorMessage = "Address is required")]
        [StringLength(100, ErrorMessage = "Address should be at most 100 characters")]
        public string Address { get; set; }

        [Required]
        [RegularExpression(@"^\d{10}$", ErrorMessage = "Invalid phone number format")]
        public long PhoneNumber { get; set; }
    }
}
