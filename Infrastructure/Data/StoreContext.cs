using Microsoft.EntityFrameworkCore;
using Core.Entities;
namespace Infrastructure.Data;
using Infrastructure.Config;

public class StoreContext(DbContextOptions options) : DbContext(options)
{
    public DbSet<Post> Posts { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfigurationsFromAssembly(typeof(PostConfiguration).Assembly);
    }
}

