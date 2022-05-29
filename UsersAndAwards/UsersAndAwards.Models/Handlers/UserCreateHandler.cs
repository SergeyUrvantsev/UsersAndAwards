using System.ComponentModel.DataAnnotations;

namespace UsersAndAwards.Models.Handlers
{
    public class UserCreateHandler
    {
        [StringLength(250, MinimumLength = 1)]
        [Display(Name = "Name")]
        [Required]
        public string Name { get; set; }

        [Display(Name = "Date of Birth")]
        [DataType(DataType.Date)]
        [Required]
        public DateTime DateOfBirth { get; set; }
    }
}
