using System.ComponentModel.DataAnnotations;

namespace UsersAndAwards.Models.Handlers
{
    public class AwardCreateHandler
    {
        [StringLength(250, MinimumLength = 1)]
        [Display(Name = "Title")]
        [Required]
        public string Title { get; set; }
    }
}
