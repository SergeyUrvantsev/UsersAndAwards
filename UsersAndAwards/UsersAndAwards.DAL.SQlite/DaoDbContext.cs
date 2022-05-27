using Microsoft.EntityFrameworkCore;
using UsersAndAwards.Entities;
using UsersAndAwards.DAL.SQLiteDAO.Interfaces;
using UsersAndAwards.DAL.SQLiteDAO.EntityTypeConfigurations;

namespace UsersAndAwards.DAL.SQLiteDAO
{
    public class DaoDbContext : DbContext, IUsersDbContext, IAwardsDbContext
    {
        public DbSet<UserEntity> Users { get; set; }
        public DbSet<AwardEntity> Awards { get; set; }

        public DaoDbContext(DbContextOptions<DaoDbContext> options)
            : base(options) { }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlite("Filename=SqliteDbEfcoreUsersAndAwards.sqlite");
        //}

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new UserConfiguration());
            base.OnModelCreating(builder);
        }
    }
}
