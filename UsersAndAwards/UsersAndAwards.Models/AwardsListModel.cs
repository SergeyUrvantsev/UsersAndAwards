using System.ComponentModel.DataAnnotations;

namespace UsersAndAwards.Models
{
    public class AwardsListModel
    {
        public Guid Id { get; set; }

        [Display(Name = "Title")]
        public string Title { get; set; }
    }
}
