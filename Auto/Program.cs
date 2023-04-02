using System.Text.Json.Serialization;
using Auto.Models;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

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
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors();

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
