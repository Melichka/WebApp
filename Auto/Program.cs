using System.Text.Json.Serialization;
using ASPNetCoreApp.Models;
using Microsoft.AspNetCore.Identity;
using Auto.Models;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using WebAPI.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(
    builder =>
    {
        builder.WithOrigins("http://localhost:3000")
    .AllowAnyHeader()
    .AllowAnyMethod();

    });
});

builder.Services.AddIdentity<User, IdentityRole>()
.AddEntityFrameworkStores<AutoContext>();

builder.Services.AddDbContext<AutoContext>();
builder.Services.AddControllers().AddJsonOptions(x =>
x.JsonSerializerOptions.ReferenceHandler =
ReferenceHandler.IgnoreCycles);
// Add services to the container.

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var autoContext = scope.ServiceProvider.GetRequiredService<AutoContext>();
    await AutoContextSeed.SeedAsync(autoContext);
    await IdentitySeed.CreateUserRoles(scope.ServiceProvider);
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

builder.Services.ConfigureApplicationCookie(options =>
{
    options.Cookie.Name = "AutoInsuranceApp";
    options.LoginPath = "/";
    options.AccessDeniedPath = "/";
    options.LogoutPath = "/";
    options.Events.OnRedirectToLogin = context =>
    {
        context.Response.StatusCode = 401;
        return Task.CompletedTask;
    };
    // Возвращать 401 при вызове недоступных методов для роли
    options.Events.OnRedirectToAccessDenied = context =>
    {
        context.Response.StatusCode = 401;
        return Task.CompletedTask;
    };
});

builder.Services.Configure<IdentityOptions>(options =>
{
    options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
    options.Lockout.MaxFailedAccessAttempts = 5;
    options.Lockout.AllowedForNewUsers = true;
});

app.UseHttpsRedirection();

app.UseCors();

app.UseAuthorization();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
//{
//    insuranceType.map(({ insuranceTypeId, Name }) => (
//                        < div className = "InsuranceType" key ={ insuranceTypeId}
//    id ={ insuranceTypeId} >
//                             < br />{ Name} < hr />
//                        </ div >
//                    ))}
