using Microsoft.EntityFrameworkCore;
using UsersAndAwards.Tests.DalTests.SqliteDaoTests.Common;
using UsersAndAwards.Domain;
using UsersAndAwards.Exceptions;
using UsersAndAwards.Tests.Common;
using Xunit;


namespace UsersAndAwards.Tests.DalTests.SqliteDaoTests.Commands
{
    public class UppdateCommandHandlerTests : TestBase
    {
        [Fact]
        public async Task UppdateUserCommandHandler_Success()
        {
            //Arrange
            var userDomain = new User
            {
                Id = DbContextFactory.UserAId,
                Name = "New name",
                DateOfBirth = DateTime.MinValue
            };

            //Act
            await SqliteDao.UpdateUserCommand(userDomain);

            //Assert
            Assert.NotNull(
                await Context.Users.SingleOrDefaultAsync(user =>
                    user.Id == userDomain.Id && user.Name == userDomain.Name &&
                    user.DateOfBirth == userDomain.DateOfBirth));
        }

        [Fact]
        public async Task UppdateUserCommandHandler_FailOnWrongId()
        {
            // Arrange
            var userDomain = new User
            {
                Id = Guid.NewGuid(),
                Name = "New name",
                DateOfBirth = DateTime.MinValue
            };
            //Act
            //Assert
            await Assert.ThrowsAsync<NotFoundException>(async () =>
                await SqliteDao.UpdateUserCommand(userDomain));
        }

        [Fact]
        public async Task UppdateAwardCommandHandler_Success()
        {
            //Arrange
            var awardDomain = new Award
            {
                Id = DbContextFactory.AwardAId,
                Title = "New title"
            };

            //Act
            await SqliteDao.UpdateAwardCommand(awardDomain);

            //Assert
            Assert.NotNull(
                await Context.Awards.SingleOrDefaultAsync(award =>
                    award.Id == awardDomain.Id && award.Title == awardDomain.Title));
        }

        [Fact]
        public async Task UppdateAwardCommandHandler_FailOnWrongId()
        {
            // Arrange
            var awardDomain = new Award
            {
                Id = Guid.NewGuid(),
                Title = "New title"
            };

            //Act
            //Assert
            await Assert.ThrowsAsync<NotFoundException>(async () =>
                await SqliteDao.UpdateAwardCommand(awardDomain));
        }
    }
}
