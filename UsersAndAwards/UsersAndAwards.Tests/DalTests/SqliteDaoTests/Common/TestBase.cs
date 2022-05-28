using UsersAndAwards.DAL.Interfaces;
using UsersAndAwards.DAL.SQLiteDAO;
using UsersAndAwards.Tests.Common;

namespace UsersAndAwards.Tests.DalTests.SqliteDaoTests.Common
{
    public abstract class TestBase : IDisposable
    {
        protected readonly DaoDbContext Context;
        protected readonly IUserAndAwardsDAO SqliteDao;

        public TestBase()
        {
            Context = DbContextFactory.Create();
            SqliteDao = new SqliteDAO(Context);
        }

        public void Dispose()
        {
            DbContextFactory.Destroy(Context);
        }
    }
}
