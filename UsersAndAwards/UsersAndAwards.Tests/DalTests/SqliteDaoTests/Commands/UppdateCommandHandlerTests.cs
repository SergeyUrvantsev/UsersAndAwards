using Microsoft.EntityFrameworkCore;
using UsersAndAwards.Tests.DalTests.SqliteDaoTests.Common;
using UsersAndAwards.Entities;
using UsersAndAwards.Exceptions;
using Xunit;

namespace UsersAndAwards.Tests.DalTests.SqliteDaoTests.Commands
{
    public class UppdateCommandHandlerTests : TestCommandBase
    {
        [Fact]
        public async Task UppdateUserCommandHandler_Success()
        {
            //Arrange
            var userEntity = new UserEntity
            {
                Id = DbContextFactory.UserAId,
                Name = "New name",
                DateOfBirth = DateTime.MinValue
            };

            //Act
            await SqliteDao.UpdateUserCommand(userEntity);

            //Assert
            Assert.NotNull(
                await Context.Users.SingleOrDefaultAsync(user =>
                    user.Id == userEntity.Id && user.Name == userEntity.Name &&
                    user.DateOfBirth == userEntity.DateOfBirth));
        }

        [Fact]
        public async Task UppdateUserCommandHandler_FailOnWrongId()
        {
            // Arrange
            var userEntity = new UserEntity
            {
                Id = Guid.NewGuid(),
                Name = "New name",
                DateOfBirth = DateTime.MinValue
            };
            //Act
            //Assert
            await Assert.ThrowsAsync<NotFoundException>(async () =>
                await SqliteDao.UpdateUserCommand(userEntity));
        }

        [Fact]
        public async Task UppdateAwardCommandHandler_Success()
        {
            //Arrange
            var awardEntity = new AwardEntity
            {
                Id = DbContextFactory.AwardAId,
                Title = "New title"
            };

            //Act
            await SqliteDao.UpdateAwardCommand(awardEntity);

            //Assert
            Assert.NotNull(
                await Context.Awards.SingleOrDefaultAsync(award =>
                    award.Id == awardEntity.Id && award.Title == awardEntity.Title));
        }

        [Fact]
        public async Task UppdateAwardCommandHandler_FailOnWrongId()
        {
            // Arrange
            var awardEntity = new AwardEntity
            {
                Id = Guid.NewGuid(),
                Title = "New title"
            };

            //Act
            //Assert
            await Assert.ThrowsAsync<NotFoundException>(async () =>
                await SqliteDao.UpdateAwardCommand(awardEntity));
        }
    }
}
