using UsersAndAwards.BLL.Interfaces;
using UsersAndAwards.DAL.Interfaces;
using UsersAndAwards.Domain;
using UsersAndAwards.Models;
using UsersAndAwards.Mappings;

namespace UsersAndAwards.BLL
{
    public class UsersAndAwardsLogic :  IUsersAndAwardsLogic
    {
        private readonly IUserAndAwardsDAO _dao;

        private List<string> Titles;

        public UsersAndAwardsLogic(IUserAndAwardsDAO dao)
        {
            _dao = dao;
            Сaching();
        }

        public async void Сaching()
        {
            Titles = (await _dao.GetAllAwardsQuery())
                .Select(award => award.Title)
                .ToList();


        }


        #region Commands

        public async Task<Guid> CreateUserCommand(string name, DateTime DateOfBirth)
        {
            var user = new User
            {
                Id = Guid.NewGuid(),
                Name = name,
                DateOfBirth = DateOfBirth
            };

            await _dao.CreateUserCommand(user);

            return user.Id;
        }

        public async Task UpdateUserCommand(Guid userId, string name, DateTime DateOfBirth)
        {
            var user = new User
            {
                Id = userId,
                Name = name,
                DateOfBirth = DateOfBirth
            };

            await _dao.UpdateUserCommand(user);
        }

        public async Task DeleteUserCommand(Guid userId)
        {
            await _dao.DeleteUserCommand(userId);
        }

        public async Task<Guid> CreateAwardCommand(string title)
        {
            var award = new Award
            {
                Id = Guid.NewGuid(),
                Title = title
            };

            await _dao.CreateAwardCommand(award);

            Titles.Add(award.Title);

            return award.Id;
        }
        public async Task UpdateAwardCommand(Guid awardId, string title)
        {
            var award = new Award
            {
                Id = awardId,
                Title = title
            };

            await _dao.UpdateAwardCommand(award);

            Сaching();
        }
        public async Task DeleteAwardCommand(Guid awardId)
        {
            await _dao.DeleteAwardCommand(awardId);

            Сaching();
        }

        public async Task AddAwardToUser(Guid userId, Guid awardId)
        {
            await _dao.AddAwardToUser(userId, awardId);
        }
        public async Task RemoveAwardAtUser(Guid userId, Guid awardId)
        {
            await _dao.RemoveAwardAtUser(userId, awardId);
        }

        #endregion

        #region Queries

        public async Task<UserModel> GetUserQuery(Guid userId)
        {
            return Mapper.UserDomainToModels(await _dao.GetUserQuery(userId));
        }

        public async Task<AwardModel> GetAwardQuery(Guid awardId)
        {
            return Mapper.AwardDomainToModels(await _dao.GetAwardQuery(awardId));
        }

        public async Task<IEnumerable<UserModel>> GetAllUsersQuery()
        {

            return (await _dao.GetAllUsersQuery())
                .Select(user => Mapper.UserDomainToModels(user))
                .ToList();
        }
        public async Task<IEnumerable<AwardModel>> GetAllAwardsQuery()
        {
            return (await _dao.GetAllAwardsQuery())
                .Select(award => Mapper.AwardDomainToModels(award))
                .ToList();
        }

        public IEnumerable<string> GetAllTitleQuery()
        {
            return Titles;
        }

        #endregion

    }
}
