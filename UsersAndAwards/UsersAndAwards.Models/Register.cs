using System.ComponentModel.DataAnnotations;

namespace UsersAndAwards.Models
{
    public class Register
    {
        [DataType(DataType.EmailAddress)]
        [Required]
        public string Email { get; set; }

        [DataType(DataType.Password)]
        [Required]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Compare(nameof(Password), ErrorMessage = "Password and confirmation password did not match")]
        [Required]
        public string ConfirmPassword { get; set; }
    }
}
