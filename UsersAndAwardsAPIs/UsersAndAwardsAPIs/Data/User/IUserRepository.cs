
public interface IUserRepository : IDisposable
{
    public Task<List<User>> GetUsersAsync();
    public Task<List<User>> GetUsersAsync(string name);

    public Task<User> GetUserAsync(Guid id);

    public Task InsertUserAsync(User user);

    public Task UpdateUserlAsync(User user);

    public Task DeleteUserAsync(Guid userId);

    public Task AddAwardToUser(Guid userId, Guid awardId);

    public Task RemoveAwardAtUser(Guid userId, Guid awardId);


    public Task SaveAsync();
}
