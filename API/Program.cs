using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Core.Interfaces;
using Infrastructure.Data.SeedData;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddDbContext<StoreContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IPostRepository, PostRepository>(); // livetime of the http request


var app = builder.Build();


app.MapControllers();

try
{
    using var scope = app.Services.CreateScope(); //to create a scope for the services and ensure they are disposed after use
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<StoreContext>();
    await context.Database.MigrateAsync(); // apply any pending migrations to the database
    await StoreContextSeed.SeedAsync(context); 
}
catch (Exception ex)
{
    Console.WriteLine(ex);
    throw;
}

app.Run();
