
namespace UsersAndAwards.Domain
{
    public class Award
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public IEnumerable<UsersList> Users { get; set; }
    }
}
