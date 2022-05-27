using UsersAndAwards.Tests.DalTests.SqliteDaoTests.Common;
using UsersAndAwards.Exceptions;
using Xunit;

namespace UsersAndAwards.Tests.DalTests.SqliteDaoTests.Commands
{
    public class DeleteCommandHandlerTests : TestCommandBase
    {
        [Fact]
        public async Task DeleteUserCommandHandler_Success()
        {
            //Arrange

            //Act
            await SqliteDao.DeleteUserCommand(DbContextFactory.UserAId);

            //Assert
            Assert.Null(Context.Users.SingleOrDefault(user =>
                user.Id == DbContextFactory.UserAId));
        }

        [Fact]
        public async Task DeleteUserCommandHandler_FailOnWrongId()
        {
            //Arrange
            //Act
            //Assert
            await Assert.ThrowsAsync<NotFoundException>(async () =>
                await SqliteDao.DeleteUserCommand(Guid.NewGuid()));
        }

        [Fact]
        public async Task DeleteAwardCommandHandler_Success()
        {
            //Arrange

            //Act
            await SqliteDao.DeleteAwardCommand(DbContextFactory.AwardAId);

            //Assert
            Assert.Null(Context.Awards.SingleOrDefault(award =>
                award.Id == DbContextFactory.AwardAId));
        }

        [Fact]
        public async Task DeleteAwardCommandHandler_FailOnWrongId()
        {
            //Arrange
            //Act
            //Assert
            await Assert.ThrowsAsync<NotFoundException>(async () =>
                await SqliteDao.DeleteAwardCommand(Guid.NewGuid()));
        }
    }
}
