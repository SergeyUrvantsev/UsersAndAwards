using Microsoft.EntityFrameworkCore;
using UsersAndAwards.Tests.DalTests.SqliteDaoTests.Common;
using UsersAndAwards.Entities;
using Xunit;

namespace UsersAndAwards.Tests.DalTests.SqliteDaoTests.Commands
{
    public class CreateCommandHandlerTests : TestCommandBase
    {
        [Fact]
        public async Task CreateUserCommandHandler_Success()
        {
            // Arrange
            var userEntity = new UserEntity
            {
                Id = Guid.NewGuid(),
                Name = "Name",
                DateOfBirth = DateTime.Today
            };

            //Act
            await SqliteDao.CreateUserCommand(userEntity);

            //Assert
            Assert.NotNull(
                await Context.Users.SingleOrDefaultAsync(user =>
                    user.Id == userEntity.Id && user.Name == userEntity.Name &&
                    user.DateOfBirth == userEntity.DateOfBirth));

        }

        [Fact]
        public async Task CreateAwardCommandHandler_Success()
        {
            // Arrange
            var awardEntity = new AwardEntity
            {
                Id = Guid.NewGuid(),
                Title = "Title"
            };

            //Act
            await SqliteDao.CreateAwardCommand(awardEntity);

            //Assert
            Assert.NotNull(
                await Context.Awards.SingleOrDefaultAsync(award =>
                    award.Id == awardEntity.Id && award.Title == awardEntity.Title));

        }
    }
}
