using UsersAndAwards.Tests.BllTests.LogicTests.Common;
using UsersAndAwards.Exceptions;
using UsersAndAwards.Tests.Common;
using UsersAndAwards.Models;
using Xunit;
using Shouldly;

namespace UsersAndAwards.Tests.BllTests.LogicTests.Queries
{
    public class GetAllQueryHandlerTests : TestBase
    {
        [Fact]
        public async Task GetAllUsersQueryHandler_Success()
        {
            //Arrange
            //Act
            var usersList = await Bll.GetAllUsersQuery();

            //Assert
            usersList.ShouldBeOfType<List<UserModel>>();
            usersList.Count().ShouldBe(2);
        }

        [Fact]
        public async Task GetAllAwardsQueryHandler_Success()
        {
            //Arrange
            //Act
            var awardsList = await Bll.GetAllAwardsQuery();

            //Assert
            awardsList.ShouldBeOfType<List<AwardModel>>();
            awardsList.Count().ShouldBe(2);
        }
    }
}
