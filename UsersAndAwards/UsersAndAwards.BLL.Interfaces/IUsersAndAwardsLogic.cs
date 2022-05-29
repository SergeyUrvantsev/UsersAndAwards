using UsersAndAwards.Models;

namespace UsersAndAwards.BLL.Interfaces
{
    public interface IUsersAndAwardsLogic
    {
        #region Commands

        public Task<Guid> CreateUserCommand(string name, DateTime DateOfBirth);
        public Task UpdateUserCommand(Guid userId, string name, DateTime DateOfBirth);
        public Task DeleteUserCommand(Guid userId);

        public Task<Guid> CreateAwardCommand(string title);
        public Task UpdateAwardCommand(Guid awardId, string title);
        public Task DeleteAwardCommand(Guid awardId);

        public Task AddAwardToUser(Guid userId, Guid awardId);
        public Task RemoveAwardAtUser(Guid userId, Guid awardId);

        #endregion

        #region Queries

        public Task<UserModel> GetUserQuery(Guid userId);
        public Task<AwardModel> GetAwardQuery(Guid awardId);

        public Task<IEnumerable<UserModel>> GetAllUsersQuery();
        public Task<IEnumerable<AwardModel>> GetAllAwardsQuery();

        public IEnumerable<string> GetAllTitleQuery();

        #endregion
    }
}
