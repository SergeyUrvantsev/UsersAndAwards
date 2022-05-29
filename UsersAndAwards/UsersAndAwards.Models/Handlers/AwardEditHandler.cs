using System.ComponentModel.DataAnnotations;

namespace UsersAndAwards.Models.Handlers
{
    public class AwardEditHandler
    {
        public Guid Id { get; set; }

        [StringLength(250, MinimumLength = 1)]
        [Display(Name = "Title")]
        [Required]
        public string Title { get; set; }
    }
}
