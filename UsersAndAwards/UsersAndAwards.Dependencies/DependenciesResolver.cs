using Microsoft.EntityFrameworkCore;
using UsersAndAwards.BLL.Interfaces;
using UsersAndAwards.BLL;
using UsersAndAwards.DAL.Interfaces;
using UsersAndAwards.DAL.SQLiteDAO;

namespace UsersAndAwards.Dependencies
{
    public class DependenciesResolver
    {
        #region SINGLETON

        private static DependenciesResolver _instance;

        private DependenciesResolver() { }

        public static DependenciesResolver Instance => _instance ??= new DependenciesResolver();

        #endregion

        private IUserAndAwardsDAO _usersAndAwardsDAO;
        public IUserAndAwardsDAO UsersAndAwardsDAO => _usersAndAwardsDAO ??= 
            new SqliteDAO(new DbContextOptionsBuilder<DaoDbContext>()
                .UseSqlite("Filename=SqliteDbEfcoreUsersAndAwards.sqlite").Options);

        private IUsersAndAwardsLogic _usersAndAwardsLogic;
        public IUsersAndAwardsLogic UsersAndAwardsBLL => _usersAndAwardsLogic ??= new UsersAndAwardsLogic(UsersAndAwardsDAO);
    }
}
