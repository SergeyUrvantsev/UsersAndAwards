using System;
using System.Linq;
using UsersAndAwards.BLL.Interfaces;
using UsersAndAwards.DAL.Interfaces;
using UsersAndAwards.Entities;
using UsersAndAwards.Domain;
using UsersAndAwards.Mappings;

namespace UsersAndAwards.BLL
{
    public class UsersAndAwardsLogic :  IUsersAndAwardsLogic
    {
        private readonly IUserAndAwardsDAO _dao;

        public UsersAndAwardsLogic(IUserAndAwardsDAO dao) =>
            _dao = dao;


        #region Commands

        public async Task CreateUserCommand(string name, DateTime DateOfBirth)
        {
            var user = new UserEntity
            {
                Id = Guid.NewGuid(),
                Name = name,
                DateOfBirth = DateOfBirth,
                Awards = new List<AwardEntity>()
            };

            await _dao.CreateUserCommand(user);
        }

        public async Task UpdateUserCommand(Guid userId, string name, DateTime DateOfBirth)
        {
            var user = new UserEntity
            {
                Id = userId,
                Name = name,
                DateOfBirth = DateOfBirth,
            };

            await _dao.UpdateUserCommand(user);
        }

        public Task DeleteUserCommand(Guid userId)
        {
            return _dao.DeleteUserCommand(userId);
        }

        public async Task CreateAwardCommand(string title)
        {
            var award = new AwardEntity
            {
                Id = Guid.NewGuid(),
                Title = title,
                Users = new List<UserEntity>()
            };

            await _dao.CreateAwardCommand(award);
        }
        public async Task UpdateAwardCommand(Guid awardId, string title)
        {
            var award = new AwardEntity
            {
                Id = awardId,
                Title = title
            };

            await _dao.UpdateAwardCommand(award);
        }
        public async Task DeleteAwardCommand(Guid awardId)
        {
            await _dao.DeleteAwardCommand(awardId);
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

        public async Task<User> GetUserQuery(Guid userId)
        {
            return Mapper.UserToDomain(await _dao.GetUserQuery(userId));
        }

        public async Task<Award> GetAwardQuery(Guid awardId)
        {
            return Mapper.AwardToDomain(await _dao.GetAwardQuery(awardId));
        }

        public async Task<IEnumerable<User>> GetAllUsersQuery()
        {

            return (await _dao.GetAllUsersQuery())
                .Select(user => Mapper.UserToDomain(user))
                .ToList();
        }
        public async Task<IEnumerable<Award>> GetAllAwardsQuery()
        {
            return (await _dao.GetAllAwardsQuery())
                .Select(award => Mapper.AwardToDomain(award))
                .ToList();
        }

        #endregion

    }
}
