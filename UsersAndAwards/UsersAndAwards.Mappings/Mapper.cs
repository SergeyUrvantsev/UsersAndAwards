using UsersAndAwards.Domain;
using UsersAndAwards.Entities;
using UsersAndAwards.Models;

namespace UsersAndAwards.Mappings
{
    public static class Mapper
    {
        public static User UserEntityToUserDomain(UserEntity userEntity)
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

        public static Award AwardEntityToAwardDomain(AwardEntity awardEntity)
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

        public static UserModel UserDomainToModels(User user)
        {
            return new UserModel
            {
                Id = user.Id,
                Name = user.Name,
                DateOfBirth = user.DateOfBirth,
                Age = user.Age,
                Awards = user.Awards.Select(award =>
                    new AwardsListModel
                    {
                        Id = award.Id,
                        Title = award.Title
                    })
                    .ToList()
            };
        }

        public static AwardModel AwardDomainToModels(Award award)
        {
            return new AwardModel
            {
                Id = award.Id,
                Title = award.Title,
                Users = award.Users.Select(user =>
                    new UsersListModel
                    {
                        Id = user.Id,
                        Name = user.Name
                    })
                    .ToList()
            };
        }

        public static User UserModelToUserDomain(UserModel user)
        {
            return new User
            {
                Id = user.Id,
                Name = user.Name,
                DateOfBirth = user.DateOfBirth,
                Age = user.Age,
                Awards = user.Awards.Select(award =>
                    new AwardsList
                    {
                        Id = award.Id,
                        Title = award.Title
                    })
                    .ToList()
            };
        }

        public static Award AwardModelToAwardDomain(AwardModel award)
        {
            return new Award
            {
                Id = award.Id,
                Title = award.Title,
                Users = award.Users.Select(user =>
                    new UsersList
                    {
                        Id = user.Id,
                        Name = user.Name
                    })
                    .ToList()
            };
        }

        public static UserEntity UserDomainToUserEntity(User user)
        {
            return new UserEntity
            {
                Id = user.Id,
                Name = user.Name,
                DateOfBirth = user.DateOfBirth,
                Awards = new List<AwardEntity>()
            };
        }

        public static AwardEntity AwardDomainToAwardEntity(Award award)
        {
            return new AwardEntity
            {
                Id = award.Id,
                Title = award.Title,
                Users = new List<UserEntity>()
            };
        }
    }
}
