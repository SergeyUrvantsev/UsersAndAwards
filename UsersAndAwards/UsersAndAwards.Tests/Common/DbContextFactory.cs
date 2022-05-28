using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.InMemory;
using UsersAndAwards.DAL.SQLiteDAO;
using UsersAndAwards.Entities;

namespace UsersAndAwards.Tests.Common
{
    public class DbContextFactory
    {
        public static Guid UserAId = Guid.NewGuid();
        public static Guid UserBId = Guid.NewGuid();

        public static Guid AwardAId = Guid.NewGuid();
        public static Guid AwardBId = Guid.NewGuid();

        public static DaoDbContext Create()
        {
            var options = new DbContextOptionsBuilder<DaoDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;

            var DbContext = new DaoDbContext(options);

            DbContext.Database.EnsureCreated();


            var userB = new UserEntity
            {
                Id = UserBId,
                Name = "UserB",
                DateOfBirth = DateTime.Today,
                Awards = new List<AwardEntity>()
            };

            var awardB = new AwardEntity
            {
                Id = AwardBId,
                Title = "AwardB",
                Users = new List<UserEntity>()
            };

            DbContext.Users.AddRange(
                new UserEntity
                {
                    Id = UserAId,
                    Name = "UserA",
                    DateOfBirth = DateTime.Today,
                    Awards = new List<AwardEntity>()
                },
                userB
            );

            DbContext.Awards.AddRange(
                new AwardEntity
                {
                    Id = AwardAId,
                    Title = "AwardA",
                    Users = new List<UserEntity>()
                },
                awardB
            );

            userB.Awards.Add(awardB);

            DbContext.SaveChanges();

            return DbContext;
        }

        public static void Destroy(DaoDbContext context)
        {
            context.Database.EnsureDeleted();
            context.Dispose();
        }
    }
}
