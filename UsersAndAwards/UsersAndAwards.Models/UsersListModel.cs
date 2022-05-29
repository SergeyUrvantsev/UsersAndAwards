using System.ComponentModel.DataAnnotations;

namespace UsersAndAwards.Models
{
    public class UsersListModel
    {
        public Guid Id { get; set; }

        [Display(Name = "Username")]
        public string Name { get; set; }
    }
}
