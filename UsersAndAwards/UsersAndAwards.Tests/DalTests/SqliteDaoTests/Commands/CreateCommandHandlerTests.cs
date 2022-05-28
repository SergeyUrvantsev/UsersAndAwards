using Microsoft.EntityFrameworkCore;
using UsersAndAwards.Tests.DalTests.SqliteDaoTests.Common;
using UsersAndAwards.Entities;
using UsersAndAwards.Domain;
using Xunit;

namespace UsersAndAwards.Tests.DalTests.SqliteDaoTests.Commands
{
    public class CreateCommandHandlerTests : TestBase
    {
        [Fact]
        public async Task CreateUserCommandHandler_Success()
        {
            // Arrange
            var userDomain = new User
            {
                Id = Guid.NewGuid(),
                Name = "Name",
                DateOfBirth = DateTime.Today
            };

            //Act
            await SqliteDao.CreateUserCommand(userDomain);

            //Assert
            Assert.NotNull(
                await Context.Users.SingleOrDefaultAsync(user =>
                    user.Id == userDomain.Id && user.Name == userDomain.Name &&
                    user.DateOfBirth == userDomain.DateOfBirth));

        }

        [Fact]
        public async Task CreateAwardCommandHandler_Success()
        {
            // Arrange
            var awardDomain = new Award
            {
                Id = Guid.NewGuid(),
                Title = "Title"
            };

            //Act
            await SqliteDao.CreateAwardCommand(awardDomain);

            //Assert
            Assert.NotNull(
                await Context.Awards.SingleOrDefaultAsync(award =>
                    award.Id == awardDomain.Id && award.Title == awardDomain.Title));

        }
    }
}
