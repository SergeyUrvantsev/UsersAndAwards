var builder = WebApplication.CreateBuilder(args);

RegisterServices(builder.Services);

var app = builder.Build();

Configure(app);
RegisterApis(app);

app.Run();


void RegisterServices(IServiceCollection services)
{
    services.AddEndpointsApiExplorer();
    services.AddSwaggerGen();

    services.AddDbContext<AppDbContext>(options =>
    {
        options.UseSqlite(builder.Configuration.GetConnectionString("Sqlite"));
    });

    services.AddScoped<IUserRepository, UserRepository>();
    services.AddScoped<IAwardRepository, AwardRepository>();

    services.AddTransient<IApi, UserApi>();
    services.AddTransient<IApi, AwardApi>();
}

void Configure(WebApplication app)
{
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
        using var scope = app.Services.CreateScope();
        var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
        db.Database.EnsureCreated();
    }

    app.UseHttpsRedirection();
}

void RegisterApis(WebApplication app)
{
    var apis = app.Services.GetServices<IApi>();
    foreach (var api in apis)
    {
        if (api == null) throw new InvalidProgramException("Api not found");
        api.Register(app);
    }
}
