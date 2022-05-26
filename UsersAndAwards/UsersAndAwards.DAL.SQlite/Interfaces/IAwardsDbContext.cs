using Microsoft.EntityFrameworkCore;
using UsersAndAwards.Entities;

namespace UsersAndAwards.DAL.SQLiteDAO.Interfaces
{
    public interface IAwardsDbContext
    {
        DbSet<AwardEntity> Awards { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
