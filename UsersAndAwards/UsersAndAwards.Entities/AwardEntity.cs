using UsersAndAwards.Entities.Interfaces;

namespace UsersAndAwards.Entities
{
    public class AwardEntity : IBaseEntity
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public List<UserEntity> Users { get; set; }
    }
}
