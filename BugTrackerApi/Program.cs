using BugTrackerApi.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
//builder.Services.AddDbContext<BugEntityContext>(option => option.UseSqlServer("Server=localhost;Database=BugsDatabase;Trusted_Connection=True;"));
builder.Services.AddDbContext<BugEntityContext>(option => option.UseInMemoryDatabase("BugsDatabase"));

builder.Services.AddHttpsRedirection(options => { options.HttpsPort = 443; });

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthorization();

app.MapControllers();

app.Run();

