using UsersAndAwards.Domain;

namespace UsersAndAwards.BLL.Interfaces
{
    public interface IUsersAndAwardsLogic
    {
        #region Commands

        public Task CreateUserCommand(string name, DateTime DateOfBirth);
        public Task UpdateUserCommand(Guid userId, string name, DateTime DateOfBirth);
        public Task DeleteUserCommand(Guid userId);

        public Task CreateAwardCommand(string title);
        public Task UpdateAwardCommand(Guid awardId, string title);
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
