using UsersAndAwards.DAL.Interfaces;
using UsersAndAwards.DAL.SQLiteDAO;
using UsersAndAwards.BLL.Interfaces;
using UsersAndAwards.BLL;
using UsersAndAwards.Tests.Common;

namespace UsersAndAwards.Tests.BllTests.LogicTests.Common
{
    public abstract class TestBase : IDisposable
    {
        protected readonly DaoDbContext Context;
        protected readonly IUsersAndAwardsLogic Bll;

        public TestBase()
        {
            Context = DbContextFactory.Create();
            Bll = new UsersAndAwardsLogic(new SqliteDAO(Context));
        }

        public void Dispose()
        {
            DbContextFactory.Destroy(Context);
        }
    }
}
