using Microsoft.EntityFrameworkCore;
using UsersAndAwards.DAL.Interfaces;
using UsersAndAwards.Exceptions;
using UsersAndAwards.Mappings;
using UsersAndAwards.Domain;
using UsersAndAwards.Entities;

namespace UsersAndAwards.DAL.SQLiteDAO
{
    public class SqliteDAO : IUserAndAwardsDAO
    {
        private readonly DaoDbContext _dbContext;

        public SqliteDAO(DbContextOptions<DaoDbContext> options)
        {
            _dbContext = new DaoDbContext(options);

            //For testing
            _dbContext.Database.EnsureDeleted();
            _dbContext.Database.EnsureCreated();
        }

        public SqliteDAO(DaoDbContext context)
        {
            _dbContext = context;
        }

        #region Commands

        public async Task CreateUserCommand(User request)
        {
            
            await _dbContext.Users.AddAsync(Mapper.UserDomainToUserEntity(request));
            await _dbContext.SaveChangesAsync();
        }
        public async Task UpdateUserCommand(User request)
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

        public async Task CreateAwardCommand(Award request)
        {
            await _dbContext.Awards.AddAsync(Mapper.AwardDomainToAwardEntity(request));
            await _dbContext.SaveChangesAsync();
        }
        public async Task UpdateAwardCommand(Award request)
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
                await _dbContext.Users.FirstOrDefaultAsync(user =>
                    user.Id == userId);

            var awardEntity =
                await _dbContext.Awards.FirstOrDefaultAsync(award =>
                    award.Id == awardId);

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
        public async Task RemoveAwardAtUser(Guid userId, Guid awardId)
        {
            var userEntity =
                await _dbContext.Users.FirstOrDefaultAsync(user =>
                    user.Id == userId);

            var awardEntity =
                await _dbContext.Awards.FirstOrDefaultAsync(award =>
                    award.Id == awardId);

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

        #endregion

        #region Queries

        public async Task<User> GetUserQuery(Guid userId)
        {
            var entity =
                await _dbContext.Users.FirstOrDefaultAsync(user =>
                    user.Id == userId);

            if (entity == null)
            {
                throw new NotFoundException(nameof(UserEntity), userId);
            }

            return Mapper.UserEntityToUserDomain(entity);
        }
        public async Task<Award> GetAwardQuery(Guid awardId)
        {
            var entity =
                await _dbContext.Awards.FirstOrDefaultAsync(user =>
                    user.Id == awardId);

            if (entity == null)
            {
                throw new NotFoundException(nameof(UserEntity), awardId);
            }

            return Mapper.AwardEntityToAwardDomain(entity);
        }

        public async Task<IEnumerable<User>> GetAllUsersQuery()
        {
            return (await _dbContext.Users.ToListAsync())
                .Select(user => Mapper.UserEntityToUserDomain(user))
                .ToList();
        }
        public async Task<IEnumerable<Award>> GetAllAwardsQuery()
        {
            return (await _dbContext.Awards.ToListAsync())
                .Select(award => Mapper.AwardEntityToAwardDomain(award))
                .ToList();
        }

        #endregion

    }
}
