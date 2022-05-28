using Microsoft.EntityFrameworkCore;
using UsersAndAwards.Tests.BllTests.LogicTests.Common;
using UsersAndAwards.Exceptions;
using UsersAndAwards.Tests.Common;
using Xunit;

namespace UsersAndAwards.Tests.BllTests.LogicTests.Commands
{
    public class UppdateCommandHandlerTests : TestBase
    {
        [Fact]
        public async Task UppdateUserCommandHandler_Success()
        {
            //Arrange
            var name = "New name";
            var dob = DateTime.Today;

            //Act
            await Bll.UpdateUserCommand(DbContextFactory.UserAId, name, dob);

            //Assert
            Assert.NotNull(
                await Context.Users.SingleOrDefaultAsync(user =>
                    user.Id == DbContextFactory.UserAId && user.Name == name &&
                    user.DateOfBirth == dob));
        }

        [Fact]
        public async Task UppdateUserCommandHandler_FailOnWrongId()
        {
            // Arrange
            var name = "New name";
            var dob = DateTime.Today;

            //Act
            //Assert
            await Assert.ThrowsAsync<NotFoundException>(async () =>
                await Bll.UpdateUserCommand(Guid.NewGuid(), name, dob));
        }

        [Fact]
        public async Task UppdateAwardCommandHandler_Success()
        {
            //Arrange
            var title = "New title";

            //Act
            await Bll.UpdateAwardCommand(DbContextFactory.AwardAId, title);

            //Assert
            Assert.NotNull(
                await Context.Awards.SingleOrDefaultAsync(award =>
                    award.Id == DbContextFactory.AwardAId && award.Title == title));
        }

        [Fact]
        public async Task UppdateAwardCommandHandler_FailOnWrongId()
        {
            // Arrange
            var title = "New title";

            //Act
            //Assert
            await Assert.ThrowsAsync<NotFoundException>(async () =>
                await Bll.UpdateAwardCommand(Guid.NewGuid(), title));
        }
    }
}
