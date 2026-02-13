using Core.Entities;
using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PostsController : ControllerBase
{

    private readonly StoreContext context;
    public PostsController(StoreContext context)
    {
        this.context = context;
    }

    [HttpGet]  
    public async Task<ActionResult<IEnumerable<Post>>> GetPosts()
    {
        return await context.Posts.ToListAsync();
    }

    [HttpGet("{id:int}")] // api/posts/3
    public async Task<ActionResult<Post>> GetPost(int id)
    {
        var post = await context.Posts.FindAsync(id);
        if (post == null)
        {
            return NotFound();
        }
        return post;
    }

    [HttpPost]
    public async Task<ActionResult<Post>> CreatePost(Post post)
    {
        context.Posts.Add(post);
        await context.SaveChangesAsync();
        return CreatedAtAction(nameof(GetPost), new { id = post.Id }, post);
    }

    [HttpPut("{id:int}")]
    public async Task<ActionResult> UpdatePost(int id, Post post)
    {
        if( post.Id != id || !PostExists(id))
        {
            return BadRequest("Cannot update post. Id mismatch or post does not exist.");
        }

        context.Entry(post).State = EntityState.Modified;
        await context.SaveChangesAsync();
        return NoContent(); // 204 No Content success
        
    }

    [HttpDelete("{id:int}")]
    public async Task<ActionResult> DeletePost(int id)
    {
        var post = await context.Posts.FindAsync(id);
        if (post == null)
        {
            return NotFound();
        }
        context.Posts.Remove(post);
        await context.SaveChangesAsync();
        return NoContent();
    }


    #region Helper Methods
    private bool PostExists(int id)
    {
        return context.Posts.Any(e => e.Id == id);
    }
    #endregion

}
