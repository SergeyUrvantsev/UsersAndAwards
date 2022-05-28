using UsersAndAwards.Tests.BllTests.LogicTests.Common;
using UsersAndAwards.Exceptions;
using UsersAndAwards.Tests.Common;
using Xunit;

namespace UsersAndAwards.Tests.BllTests.LogicTests.Commands
{
    public class DeleteCommandHandlerTests : TestBase
    {
        [Fact]
        public async Task DeleteUserCommandHandler_Success()
        {
            //Arrange

            //Act
            await Bll.DeleteUserCommand(DbContextFactory.UserAId);

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
                await Bll.DeleteUserCommand(Guid.NewGuid()));
        }

        [Fact]
        public async Task DeleteAwardCommandHandler_Success()
        {
            //Arrange

            //Act
            await Bll.DeleteAwardCommand(DbContextFactory.AwardAId);

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
                await Bll.DeleteAwardCommand(Guid.NewGuid()));
        }
    }
}
