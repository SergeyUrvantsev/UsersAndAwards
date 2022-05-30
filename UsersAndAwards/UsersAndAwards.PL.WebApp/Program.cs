using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using UsersAndAwards.PL.WebApp.Model;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

builder.Services.AddDbContextPool<AuthDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("AuthConnectiomString")));

builder.Services.AddIdentity<IdentityUser, IdentityRole>()
    .AddEntityFrameworkStores<AuthDbContext>();

builder.Services.ConfigureApplicationCookie(config =>
{
    config.LoginPath = "/Login";
});

var app = builder.Build();


// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    var a = UsersAndAwards.Dependencies.DependenciesResolver.Instance.UsersAndAwardsBLL;
    app.UseDeveloperExceptionPage();
}
else if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapRazorPages();

app.Run();
