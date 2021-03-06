using System.ComponentModel.DataAnnotations;

namespace UsersAndAwards.Models
{
    public class AwardModel
    {
        public Guid Id { get; set; }

        [StringLength(250, MinimumLength = 1)]
        [Display(Name = "Title")]
        [Required]
        public string Title { get; set; }

        public IEnumerable<UsersListModel> Users { get; set; }
    }
}
