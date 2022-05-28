
namespace UsersAndAwards.Models
{
    public class UserModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int Age { get; set; }
        public IEnumerable<AwardsListModel> Awards { get; set; }
    }
}
