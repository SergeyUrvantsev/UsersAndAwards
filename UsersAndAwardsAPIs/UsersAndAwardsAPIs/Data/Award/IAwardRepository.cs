
public interface IAwardRepository : IDisposable
{
    public Task<List<Award>> GetAwardsAsync();
    public Task<List<Award>> GetAwardsAsync(string title);

    public Task<Award> GetAwardAsync(Guid awardId);

    public Task InsertAwardAsync(Award award);

    public Task UpdateAwardlAsync(Award award);

    public Task DeleteAwardAsync(Guid awardId);


    public Task SaveAsync();
}