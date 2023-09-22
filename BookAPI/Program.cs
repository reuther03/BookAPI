using BookAPI;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Writers;

var builder = WebApplication.CreateBuilder(args);

#region services

var services = builder.Services;

services.AddControllers();
services.AddEndpointsApiExplorer();
services.AddSwaggerGen();
services.AddMvc();

var connectionString = builder.Configuration["ConnectionStrings:BookDb"];
services.AddDbContext<BookDbContext>(c => c.UseSqlite(connectionString));

// DI
services.AddScoped<ICountryRepository, CountryRepository>();

#endregion

#region app

var app = builder.Build();

using var scope = app.Services.CreateScope();
var context = scope.ServiceProvider.GetRequiredService<BookDbContext>();
context.Database.EnsureCreated();
context.Database.Migrate();

if (!context.Books.Any() && !context.Authors.Any() && !context.Reviews.Any())
{
    context.SeedDataContext();
}

app.UseSwagger();
app.UseSwaggerUI();

app.MapControllers();

#endregion
app.Run();
