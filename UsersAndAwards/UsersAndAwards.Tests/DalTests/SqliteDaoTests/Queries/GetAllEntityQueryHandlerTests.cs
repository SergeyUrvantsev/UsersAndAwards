using UsersAndAwards.Tests.DalTests.SqliteDaoTests.Common;
using UsersAndAwards.Exceptions;
using UsersAndAwards.Domain;
using UsersAndAwards.Entities;
using Xunit;
using Shouldly;

namespace UsersAndAwards.Tests.DalTests.SqliteDaoTests.Queries
{
    public class GetAllEntityQueryHandlerTests : TestBase
    {
        [Fact]
        public async Task GetAllUsersQueryHandler_Success()
        {
            //Arrange
            //Act
            var usersList = await SqliteDao.GetAllUsersQuery();

            //Assert
            usersList.ShouldBeOfType<List<User>>();
            usersList.Count().ShouldBe(2);
        }

        [Fact]
        public async Task GetAllAwardsQueryHandler_Success()
        {
            //Arrange
            //Act
            var awardsList = await SqliteDao.GetAllAwardsQuery();

            //Assert
            awardsList.ShouldBeOfType<List<Award>>();
            awardsList.Count().ShouldBe(2);
        }

    }
}
