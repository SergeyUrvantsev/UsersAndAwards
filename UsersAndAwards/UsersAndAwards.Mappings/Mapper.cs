using UsersAndAwards.Domain;
using UsersAndAwards.Entities;

namespace UsersAndAwards.Mappings
{
    public static class Mapper
    {
        public static User UserToDomain(UserEntity userEntity)
        {
            int age = DateTime.Now.Year - userEntity.DateOfBirth.Year;
            if (userEntity.DateOfBirth > DateTime.Now.AddYears(-age)) age--;

            return new User
            {
                Id = userEntity.Id,
                Name = userEntity.Name,
                DateOfBirth = userEntity.DateOfBirth,
                Age = age,
                Awards = userEntity.Awards.Select(award =>
                    new AwardsList
                    {
                        Id = award.Id,
                        Title = award.Title
                    })
                    .ToList()
            };
        }

        public static Award AwardToDomain(AwardEntity awardEntity)
        {
            return new Award
            {
                Id = awardEntity.Id,
                Title = awardEntity.Title,
                Users = awardEntity.Users.Select(user =>
                    new UsersList
                    {
                        Id = user.Id,
                        Name = user.Name
                    })
                    .ToList()
            };
        }
    }
}
