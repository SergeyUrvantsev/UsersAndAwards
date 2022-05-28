using UsersAndAwards.Tests.BllTests.LogicTests.Common;
using UsersAndAwards.Exceptions;
using UsersAndAwards.Tests.Common;
using UsersAndAwards.Models;
using Xunit;
using Shouldly;

namespace UsersAndAwards.Tests.BllTests.LogicTests.Queries
{
    public class GetQueryHandlerTests : TestBase
    {
        [Fact]
        public async Task GetUserQueryHandler_Success()
        {
            //Arrange
            //Act
            var userB = await Bll.GetUserQuery(DbContextFactory.UserBId);

            //Assert
            userB.ShouldBeOfType<UserModel>();
            userB.Name.ShouldBe("UserB");
            userB.DateOfBirth.ShouldBe(DateTime.Today);
            userB.Awards.Count().ShouldBe(1);
        }

        [Fact]
        public async Task GetUserQueryHandler_FailOnWrongId()
        {
            //Arrange
            //Act
            //Assert
            await Assert.ThrowsAsync<NotFoundException>(async () =>
                await Bll.GetUserQuery(Guid.NewGuid()));
        }

        [Fact]
        public async Task GetAwardQueryHandler_Success()
        {
            //Arrange
            //Act
            var awardB = await Bll.GetAwardQuery(DbContextFactory.AwardBId);

            //Assert
            awardB.ShouldBeOfType<AwardModel>();
            awardB.Title.ShouldBe("AwardB");
            awardB.Users.Count().ShouldBe(1);
        }

        [Fact]
        public async Task GetAwardQueryHandler_FailOnWrongId()
        {
            //Arrange
            //Act
            //Assert
            await Assert.ThrowsAsync<NotFoundException>(async () =>
                await Bll.GetAwardQuery(Guid.NewGuid()));
        }
    }
}
