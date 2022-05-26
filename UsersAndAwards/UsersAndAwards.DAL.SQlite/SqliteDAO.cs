using Microsoft.EntityFrameworkCore;
using UsersAndAwards.DAL.Interfaces;
using UsersAndAwards.Exceptions;
using UsersAndAwards.Entities;

namespace UsersAndAwards.DAL.SQLiteDAO
{
    public class SqliteDAO : IUserAndAwardsDAO
    {
        private readonly DaoDbContext _dbContext = new DaoDbContext();

        public SqliteDAO()
        {
            //For testing
            _dbContext.Database.EnsureDeleted();
            _dbContext.Database.EnsureCreated();
        }


        #region Commands

        public async Task CreateUserCommand(UserEntity request)
        {
            await _dbContext.Users.AddAsync(request);
            await _dbContext.SaveChangesAsync();
        }
        public async Task UpdateUserCommand(UserEntity request)
        {
            var entity =
                await _dbContext.Users.FirstOrDefaultAsync(user =>
                    user.Id == request.Id);

            if (entity == null)
            {
                throw new NotFoundException(nameof(UserEntity), request.Id);
            }

            entity.Name = request.Name;
            entity.DateOfBirth = request.DateOfBirth;

            await _dbContext.SaveChangesAsync();
        }
        public async Task DeleteUserCommand(Guid userId)
        {
            var entity =
                await _dbContext.Users.FindAsync(new object[] { userId });

            if (entity == null)
            {
                throw new NotFoundException(nameof(UserEntity), userId);
            }

            _dbContext.Users.Remove(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task CreateAwardCommand(AwardEntity request)
        {
            await _dbContext.Awards.AddAsync(request);
            await _dbContext.SaveChangesAsync();
        }
        public async Task UpdateAwardCommand(AwardEntity request)
        {
            var entity =
                await _dbContext.Awards.FirstOrDefaultAsync(award =>
                    award.Id == request.Id);

            if (entity == null)
            {
                throw new NotFoundException(nameof(AwardEntity), request.Id);
            }

            entity.Title = request.Title;

            await _dbContext.SaveChangesAsync();
        }
        public async Task DeleteAwardCommand(Guid awardId)
        {
            var entity =
                await _dbContext.Awards.FindAsync(new object[] { awardId });

            if (entity == null)
            {
                throw new NotFoundException(nameof(AwardEntity), awardId);
            }

            _dbContext.Awards.Remove(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task AddAwardToUser(Guid userId, Guid awardId)
        {
            var userEntity =
                await _dbContext.Users.FindAsync(new object[] { userId });

            var awardEntity =
                await _dbContext.Awards.FindAsync(new object[] { awardId });

            if (userEntity == null)
            {
                throw new NotFoundException(nameof(UserEntity), userId);
            }
            else if (awardEntity == null)
            {
                throw new NotFoundException(nameof(AwardEntity), awardId);
            }

            userEntity.Awards.Remove(awardEntity);
            await _dbContext.SaveChangesAsync();
        }
        public async Task RemoveAwardAtUser(Guid userId, Guid awardId)
        {
            var userEntity =
                await _dbContext.Users.FindAsync(new object[] { userId });

            var awardEntity =
                await _dbContext.Awards.FindAsync(new object[] { awardId });

            if (userEntity == null)
            {
                throw new NotFoundException(nameof(UserEntity), userId);
            }
            else if (awardEntity == null)
            {
                throw new NotFoundException(nameof(AwardEntity), awardId);
            }

            userEntity.Awards.Add(awardEntity);
            await _dbContext.SaveChangesAsync();
        }

        #endregion

        #region Queries

        public async Task<UserEntity> GetUserQuery(Guid userId)
        {
            var entity =
                await _dbContext.Users.FirstOrDefaultAsync(user =>
                    user.Id == userId);

            if (entity == null)
            {
                throw new NotFoundException(nameof(UserEntity), userId);
            }

            return entity;
        }
        public async Task<AwardEntity> GetAwardQuery(Guid awardId)
        {
            var entity =
                await _dbContext.Awards.FirstOrDefaultAsync(user =>
                    user.Id == awardId);

            if (entity == null)
            {
                throw new NotFoundException(nameof(UserEntity), awardId);
            }

            return entity;
        }

        public async Task<IEnumerable<UserEntity>> GetAllUsersQuery()
        {
            return await _dbContext.Users.ToListAsync();
        }
        public async Task<IEnumerable<AwardEntity>> GetAllAwardsQuery()
        {
            return await _dbContext.Awards.ToListAsync();
        }

        #endregion

    }
}
