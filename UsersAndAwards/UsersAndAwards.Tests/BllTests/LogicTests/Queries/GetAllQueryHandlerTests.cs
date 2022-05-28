using UsersAndAwards.Tests.BllTests.LogicTests.Common;
using UsersAndAwards.Exceptions;
using UsersAndAwards.Tests.Common;
using UsersAndAwards.Domain;
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
            usersList.ShouldBeOfType<List<User>>();
            usersList.Count().ShouldBe(2);
        }

        [Fact]
        public async Task GetAllAwardsQueryHandler_Success()
        {
            //Arrange
            //Act
            var awardsList = await Bll.GetAllAwardsQuery();

            //Assert
            awardsList.ShouldBeOfType<List<Award>>();
            awardsList.Count().ShouldBe(2);
        }
    }
}
