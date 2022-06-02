
public class UserApi : IApi
{
    public void Register(WebApplication app)
    {
        app.MapGet("/users", Get)
            .Produces<List<User>>(StatusCodes.Status200OK)
            .WithName("GetAllUsers")
            .WithTags("Getters");

        app.MapGet("/users/search/name/{query}", SearchByName)
            .Produces<List<User>>(StatusCodes.Status200OK)
            .Produces(StatusCodes.Status404NotFound)
            .WithName("SearchUsers")
            .WithTags("Getters");

        app.MapGet("/users/{id}", GetById)
            .Produces<User>(StatusCodes.Status200OK)
            .WithName("GetUser")
            .WithTags("Getters");

        app.MapPost("/users", Post)
            .Accepts<User>("application/json")
            .Produces<User>(StatusCodes.Status201Created)
            .WithName("CreateUser")
            .WithTags("Creators");

        app.MapPut("/users", Put)
            .Accepts<User>("application/json")
            .WithName("UpdateUser")
            .WithTags("Updaters");

        app.MapPut("/users/AwardManagement/Add/{id}", AddAwardToUser)
            .WithName("AddAwardToUser")
            .WithTags("Updaters");

        app.MapPut("/users/AwardManagement/Remove/{id}", RemoveAwardAtUser)
            .WithName("RemoveAwardAtUser")
            .WithTags("Updaters");

        app.MapDelete("/users/{id}", Delete)
            .WithName("DeleteUser")
            .WithTags("Deleters");
    }

    public async Task<IResult> Get(IUserRepository repository) =>
            Results.Ok(await repository.GetUsersAsync());

    public async Task<IResult> GetById(Guid id, IUserRepository repository) =>
            await repository.GetUserAsync(id) is User user
            ? Results.Ok(user)
            : Results.NotFound();

    public async Task<IResult> SearchByName(string query, IUserRepository repository) =>
            await repository.GetUsersAsync(query) is IEnumerable<User> users
                ? Results.Ok(users)
                : Results.NotFound(Array.Empty<User>);

    public async Task<IResult> Post([FromBody] User user, IUserRepository repository)
    {
        await repository.InsertUserAsync(user);
        await repository.SaveAsync();
        return Results.Created($"/users/{user.Id}", user);
    }

    public async Task<IResult> Put([FromBody] User user, IUserRepository repository)
    {
        await repository.UpdateUserlAsync(user);
        await repository.SaveAsync();
        return Results.NoContent();
    }

    public async Task<IResult> AddAwardToUser(Guid id, [FromBody] Guid awardId, IUserRepository repository)
    {
        await repository.AddAwardToUser(id, awardId);
        await repository.SaveAsync();
        return Results.NoContent();
    }

    public async Task<IResult> RemoveAwardAtUser(Guid id, [FromBody] Guid awardId, IUserRepository repository)
    {
        await repository.RemoveAwardAtUser(id, awardId);
        await repository.SaveAsync();
        return Results.NoContent();
    }

    public async Task<IResult> Delete(Guid id, IUserRepository repository)
    {
        await repository.DeleteUserAsync(id);
        await repository.SaveAsync();
        return Results.NoContent();
    }
}