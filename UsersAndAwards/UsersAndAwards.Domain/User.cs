
namespace UsersAndAwards.Domain
{
    public class User
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int Age { get; set; }
        public IEnumerable<AwardsList> Awards { get; set; }
    }
}
