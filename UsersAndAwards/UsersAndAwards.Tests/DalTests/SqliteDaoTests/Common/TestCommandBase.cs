using UsersAndAwards.DAL.Interfaces;
using UsersAndAwards.DAL.SQLiteDAO;

namespace UsersAndAwards.Tests.DalTests.SqliteDaoTests.Common
{
    public abstract class TestCommandBase : IDisposable
    {
        protected readonly DaoDbContext Context;
        protected readonly IUserAndAwardsDAO SqliteDao;

        public TestCommandBase()
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
