
public class AwardApi : IApi
{
    public void Register(WebApplication app)
    {
        app.MapGet("/awards", Get)
            .Produces<List<Award>>(StatusCodes.Status200OK)
            .WithName("GetAllAwards")
            .WithTags("Getters");

        app.MapGet("/awards/search/title/{query}", SearchByTitle)
            .Produces<List<Award>>(StatusCodes.Status200OK)
            .Produces(StatusCodes.Status404NotFound)
            .WithName("SearchAwards")
            .WithTags("Getters");

        app.MapGet("/awards/{id}", GetById)
            .Produces<Award>(StatusCodes.Status200OK)
            .WithName("GetAward")
            .WithTags("Getters");

        app.MapPost("/awards", Post)
            .Accepts<Award>("application/json")
            .Produces<Award>(StatusCodes.Status201Created)
            .WithName("CreateAward")
            .WithTags("Creators");

        app.MapPut("/awards", Put)
            .Accepts<Award>("application/json")
            .WithName("UpdateAward")
            .WithTags("Updaters");

        app.MapDelete("/awards/{id}", Delete)
            .WithName("DeleteAward")
            .WithTags("Deleters");
    }

    public async Task<IResult> Get(IAwardRepository repository) =>
        Results.Ok(await repository.GetAwardsAsync());

    public async Task<IResult> GetById(Guid id, IAwardRepository repository) =>
            await repository.GetAwardAsync(id) is Award award
            ? Results.Ok(award)
            : Results.NotFound();

    public async Task<IResult> SearchByTitle(string query, IAwardRepository repository) =>
            await repository.GetAwardsAsync(query) is IEnumerable<Award> awards
                ? Results.Ok(awards)
                : Results.NotFound(Array.Empty<Award>);

    public async Task<IResult> Post([FromBody] Award award, IAwardRepository repository)
    {
        await repository.InsertAwardAsync(award);
        await repository.SaveAsync();
        return Results.Created($"/users/{award.Id}", award);
    }

    public async Task<IResult> Put([FromBody] Award award, IAwardRepository repository)
    {
        await repository.UpdateAwardlAsync(award);
        await repository.SaveAsync();
        return Results.NoContent();
    }

    public async Task<IResult> Delete(Guid id, IAwardRepository repository)
    {
        await repository.DeleteAwardAsync(id);
        await repository.SaveAsync();
        return Results.NoContent();
    }

}