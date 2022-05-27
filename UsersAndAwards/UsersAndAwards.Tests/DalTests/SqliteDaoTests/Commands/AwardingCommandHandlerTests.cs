using Microsoft.EntityFrameworkCore;
using UsersAndAwards.Tests.DalTests.SqliteDaoTests.Common;
using UsersAndAwards.Exceptions;
using Xunit;

namespace UsersAndAwards.Tests.DalTests.SqliteDaoTests.Commands
{
    public class AwardingCommandHandlerTests : TestCommandBase
    {
        [Fact]
        public async Task AddAwardToUserCommandHandler_Success()
        {
            // Arrange
            //Act
            await SqliteDao.AddAwardToUser(DbContextFactory.UserAId, DbContextFactory.AwardAId);

            //Assert
            Assert.NotNull(
                await Context.Users.SingleOrDefaultAsync(user =>
                    user.Id == DbContextFactory.UserAId &&
                    user.Awards.ToList().Count == 1 &&
                    user.Awards.ToList().FirstOrDefault().Id == DbContextFactory.AwardAId));
            Assert.NotNull(
                await Context.Awards.SingleOrDefaultAsync(award =>
                    award.Id == DbContextFactory.AwardAId &&
                    award.Users.ToList().Count == 1 &&
                    award.Users.ToList().FirstOrDefault().Id == DbContextFactory.UserAId));
        }

        [Fact]
        public async Task AddAwardToUserCommandHandler_FailOnWrongId()
        {
            // Arrange
            //Act
            //Assert
            await Assert.ThrowsAsync<NotFoundException>(async () =>
                await SqliteDao.AddAwardToUser(Guid.NewGuid(), Guid.NewGuid()));
        }

        [Fact]
        public async Task RemoveAwardAtUserCommandHandler_Success()
        {
            // Arrange
            //Act
            await SqliteDao.RemoveAwardAtUser(DbContextFactory.UserBId, DbContextFactory.AwardBId);

            //Assert
            Assert.NotNull(
                await Context.Users.SingleOrDefaultAsync(user =>
                    user.Id == DbContextFactory.UserBId &&
                    user.Awards.ToList().Count == 0));
            Assert.NotNull(
                await Context.Awards.SingleOrDefaultAsync(award =>
                    award.Id == DbContextFactory.AwardBId &&
                    award.Users.ToList().Count == 0));
        }

        [Fact]
        public async Task RemoveAwardAtUserCommandHandler_FailOnWrongId()
        {
            // Arrange
            //Act
            //Assert
            await Assert.ThrowsAsync<NotFoundException>(async () =>
                await SqliteDao.RemoveAwardAtUser(Guid.NewGuid(), Guid.NewGuid()));
        }
    }
}
