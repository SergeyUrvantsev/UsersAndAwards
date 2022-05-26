
namespace UsersAndAwards.Entities
{
    public class UserEntity : IBaseEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime DateOfBirth { get; set; }
        public IEnumerable<AwardEntity> Awards { get; set; }
    }
}
