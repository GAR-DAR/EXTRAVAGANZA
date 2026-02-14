namespace Infrastructure.Data.SeedData;
using System.Text.Json;
using Core.Entities;

public class StoreContextSeed
{
    public static async Task SeedAsync(StoreContext context)
    {
        if (!context.Posts.Any())
        {
            var postsData = await File.ReadAllTextAsync("../Infrastructure/Data/SeedData/posts.json");

            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };

            var posts = JsonSerializer.Deserialize<List<Post>>(postsData, options);


            if(posts == null)
            {
                return;
            }

            context.Posts.AddRange(posts);
            await context.SaveChangesAsync();
        }
    }
}
