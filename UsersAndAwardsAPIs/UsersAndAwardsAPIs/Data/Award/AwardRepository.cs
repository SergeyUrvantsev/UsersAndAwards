
public class AwardRepository : IAwardRepository
{
    private readonly AppDbContext _context;

    public AwardRepository(AppDbContext context) =>
        _context = context;

    public Task<List<Award>> GetAwardsAsync() =>
        _context.Awards.ToListAsync();
    public Task<List<Award>> GetAwardsAsync(string title) =>
        _context.Awards.Where(award => award.Title.Contains(title)).ToListAsync();

    public async Task<Award> GetAwardAsync(Guid awardId) =>
        await _context.Awards.FindAsync(new object[] { awardId });

    public async Task InsertAwardAsync(Award award)
    {
        award.Users = new List<User>();
        await _context.Awards.AddAsync(award);
    }

    public async Task UpdateAwardlAsync(Award award)
    {
        var awardFromDb = await _context.Awards.FindAsync(new object[] { award.Id });
        if (awardFromDb == null) return;
        awardFromDb.Title = award.Title;
    }

    public async Task DeleteAwardAsync(Guid awardId)
    {
        var awardFromDb = await _context.Awards.FindAsync(new object[] { awardId });
        if (awardFromDb == null) return;
        _context.Awards.Remove(awardFromDb);
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