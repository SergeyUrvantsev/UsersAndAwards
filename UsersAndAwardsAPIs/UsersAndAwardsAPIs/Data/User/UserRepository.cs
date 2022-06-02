public class UserRepository : IUserRepository
{

    private readonly AppDbContext _context;

    public UserRepository(AppDbContext context) =>
        _context = context;

    public Task<List<User>> GetUsersAsync() =>
        _context.Users.ToListAsync();

    public Task<List<User>> GetUsersAsync(string name) =>
        _context.Users.Where(user => user.Name.Contains(name)).ToListAsync();

    public async Task<User> GetUserAsync(Guid userId) =>
        await _context.Users.FindAsync(new object[] { userId });

    public async Task InsertUserAsync(User user)
    {
        user.Awards = new List<Award>();
        await _context.Users.AddAsync(user);
    }

    public async Task UpdateUserlAsync(User user)
    {
        var userFromDb = await _context.Users.FindAsync(new object[] { user.Id });
        if (userFromDb == null) return;
        userFromDb.Name = user.Name;
        userFromDb.DateOfBirth = user.DateOfBirth;
    }

    public async Task DeleteUserAsync(Guid userId)
    {
        var userFromDb = await _context.Users.FindAsync(new object[] { userId });
        if (userFromDb == null) return;
        _context.Users.Remove(userFromDb);
    }

    public async Task AddAwardToUser(Guid userId, Guid awardId)
    {
        var userFromDb = await _context.Users.FindAsync(new object[] { userId });
        var awardFromDb = await _context.Awards.FindAsync(new object[] { awardId });

        if (userFromDb == null && awardFromDb == null) return;

        userFromDb.Awards.Add(awardFromDb);
    }

    public async Task RemoveAwardAtUser(Guid userId, Guid awardId)
    {
        var userFromDb = await _context.Users.FindAsync(new object[] { userId });
        var awardFromDb = await _context.Awards.FindAsync(new object[] { awardId });

        if (userFromDb == null && awardFromDb == null) return;

        userFromDb.Awards.Remove(awardFromDb);
    }

    #region 
    public async Task SaveAsync() => await _context.SaveChangesAsync();


    private bool _disposed = false;
    protected virtual void Dispose(bool disposing)
    {
        if (!_disposed)
        {
            if (disposing)
            {
                _context.Dispose();
            }
        }
        _disposed = true;
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    #endregion
}
