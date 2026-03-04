using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Core.Interfaces;
using Infrastructure.Data.SeedData;
using API.Middleware;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddDbContext<StoreContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IPostRepository, PostRepository>(); // livetime of the http request
builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>)); 
builder.Services.AddCors();


var app = builder.Build();

app.UseMiddleware<ExceptionMiddleware>();

app.UseCors(x => x.AllowAnyHeader().AllowAnyMethod().WithOrigins("http://localhost:4200", "https://localhost:4200")); // allow any header and method from the specified origin (React app running on localhost:3000)

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
