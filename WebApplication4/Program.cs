using Microsoft.EntityFrameworkCore;
using WebApplication4.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

IServiceCollection serviceCollection = builder.Services.AddDbContext<StudentDBContext>(options =>
{
    var connString = builder.Configuration.GetConnectionString("Default");
    options.UseMySql(connString, ServerVersion.AutoDetect(connString));
});

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseAuthorization();

app.MapControllers();

app.Run();
