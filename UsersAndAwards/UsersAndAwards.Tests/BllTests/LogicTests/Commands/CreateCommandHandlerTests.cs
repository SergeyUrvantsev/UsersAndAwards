using Microsoft.EntityFrameworkCore;
using UsersAndAwards.Tests.BllTests.LogicTests.Common;
using Xunit;

namespace UsersAndAwards.Tests.BllTests.LogicTests.Commands
{
    public class CreateCommandHandlerTests : TestBase
    {
        [Fact]
        public async Task CreateUserCommandHandler_Success()
        {
            // Arrange
            var name = "Name";
            var dob = DateTime.Today;

            //Act
            await Bll.CreateUserCommand(name, dob);

            //Assert
            Assert.NotNull(
                await Context.Users.SingleOrDefaultAsync(user =>
                    user.Name == name &&
                    user.DateOfBirth == dob));

        }

        [Fact]
        public async Task CreateAwardCommandHandler_Success()
        {
            // Arrange
            var title = "Title";

            //Act
            await Bll.CreateAwardCommand(title);

            //Assert
            Assert.NotNull(
                await Context.Awards.SingleOrDefaultAsync(award =>
                    award.Title == title));

        }
    }
}
