
namespace UsersAndAwards.Models
{
    public class AwardModel
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public IEnumerable<UsersListModel> Users { get; set; }
    }
}
