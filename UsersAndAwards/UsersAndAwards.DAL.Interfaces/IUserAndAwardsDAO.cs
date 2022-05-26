using Microsoft.EntityFrameworkCore;
using UsersAndAwards.Entities;

namespace UsersAndAwards.DAL.Interfaces
{
    public interface IUserAndAwardsDAO
    {
        #region Commands

        public Task CreateUserCommand(UserEntity request);
        public Task UpdateUserCommand(UserEntity request);
        public Task DeleteUserCommand(Guid userId);

        public Task CreateAwardCommand(AwardEntity request);
        public Task UpdateAwardCommand(AwardEntity request);
        public Task DeleteAwardCommand(Guid awardId);

        public Task AddAwardToUser(Guid userId, Guid awardId);
        public Task RemoveAwardAtUser(Guid userId, Guid awardId);

        #endregion

        #region Queries

        public Task<UserEntity> GetUserQuery(Guid userId);
        public Task<AwardEntity> GetAwardQuery(Guid awardId);

        public Task<IEnumerable<UserEntity>> GetAllUsersQuery();
        public Task<IEnumerable<AwardEntity>> GetAllAwardsQuery();

        #endregion
    }
}
