using System;
using Core.Entities;
using Core.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data;

public class PostRepository(StoreContext context) : IPostRepository
{
    public void AddPost(Post post)
    {
        context.Posts.Add(post);
    }

    public void DeletePost(Post post)
    {
        context.Posts.Remove(post);
    }

    public async Task<Post?> GetPostByIdAsync(int id)
    {
        return await context.Posts.FindAsync(id);
    }

    public async Task<IReadOnlyList<Post>> GetPostsAsync()
    {
        return await context.Posts.ToListAsync();
    }

    public bool PostExists(int id)
    {
        return context.Posts.Any(p => p.Id == id);
    }

    public async Task<bool> SaveChangesAsync()
    {
        return await context.SaveChangesAsync() > 0;
    }

    public void UpdatePost(Post post)
    {
        context.Entry(post).State = EntityState.Modified;
    }
}
