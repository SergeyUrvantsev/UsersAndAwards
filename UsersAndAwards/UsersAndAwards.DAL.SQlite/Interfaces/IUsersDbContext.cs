using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using UsersAndAwards.Entities;

namespace UsersAndAwards.DAL.SQLiteDAO.Interfaces
{
    public interface IUsersDbContext
    {
        DbSet<UserEntity> Users { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
