using UsersAndAwards.Tests.DalTests.SqliteDaoTests.Common;
using UsersAndAwards.Exceptions;
using UsersAndAwards.Domain;
using UsersAndAwards.Tests.Common;
using Xunit;
using Shouldly;

namespace UsersAndAwards.Tests.DalTests.SqliteDaoTests.Queries
{
    public class GetEntityQueryHandlerTests : TestBase
    {

        [Fact]
        public async Task GetUserEntityQueryHandler_Success()
        {
            //Arrange
            //Act
            var userA = await SqliteDao.GetUserQuery(DbContextFactory.UserAId);

            //Assert
            userA.ShouldBeOfType<User>();
            userA.Name.ShouldBe("UserA");
            userA.DateOfBirth.ShouldBe(DateTime.Today);
        }

        [Fact]
        public async Task GetUserEntityQueryHandler_FailOnWrongId()
        {
            //Arrange
            //Act
            //Assert
            await Assert.ThrowsAsync<NotFoundException>(async () =>
                await SqliteDao.GetUserQuery(Guid.NewGuid()));
        }

        [Fact]
        public async Task GetAwardEntityQueryHandler_Success()
        {
            //Arrange
            //Act
            var awardA = await SqliteDao.GetAwardQuery(DbContextFactory.AwardAId);

            //Assert
            awardA.ShouldBeOfType<Award>();
            awardA.Title.ShouldBe("AwardA");
        }

        [Fact]
        public async Task GetAwardEntityQueryHandler_FailOnWrongId()
        {
            //Arrange
            //Act
            //Assert
            await Assert.ThrowsAsync<NotFoundException>(async () =>
                await SqliteDao.GetAwardQuery(Guid.NewGuid()));
        }
    }
}
