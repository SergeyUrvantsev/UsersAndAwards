using UsersAndAwards.Domain;

namespace UsersAndAwards.DAL.Interfaces
{
    public interface IUserAndAwardsDAO
    {
        #region Commands

        public Task CreateUserCommand(User request);
        public Task UpdateUserCommand(User request);
        public Task DeleteUserCommand(Guid userId);

        public Task CreateAwardCommand(Award request);
        public Task UpdateAwardCommand(Award request);
        public Task DeleteAwardCommand(Guid awardId);

        public Task AddAwardToUser(Guid userId, Guid awardId);
        public Task RemoveAwardAtUser(Guid userId, Guid awardId);

        #endregion

        #region Queries

        public Task<User> GetUserQuery(Guid userId);
        public Task<Award> GetAwardQuery(Guid awardId);

        public Task<IEnumerable<User>> GetAllUsersQuery();
        public Task<IEnumerable<Award>> GetAllAwardsQuery();

        #endregion
    }
}
