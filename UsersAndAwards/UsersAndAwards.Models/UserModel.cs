using System.ComponentModel.DataAnnotations;

namespace UsersAndAwards.Models
{
    public class UserModel
    {
        public Guid Id { get; set; }

        [StringLength(250, MinimumLength = 1)]
        [Display(Name = "Name")]
        [Required]
        public string Name { get; set; }

        [Display(Name = "Date of Birth")]
        [DataType(DataType.Date)]
        [Required]
        public DateTime DateOfBirth { get; set; }

        [Display(Name = "Years old")]
        public int Age { get; set; }

        public IEnumerable<AwardsListModel> Awards { get; set; }
    }
}
