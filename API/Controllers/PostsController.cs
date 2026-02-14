using Core.Entities;
using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Core.Interfaces;

namespace API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PostsController(IPostRepository repo) : ControllerBase
{
    [HttpGet]  
    public async Task<ActionResult<IReadOnlyList<Post>>> GetPosts()
    {
        return Ok(await repo.GetPostsAsync());
    }

    [HttpGet("{id:int}")] // api/posts/3
    public async Task<ActionResult<Post>> GetPost(int id)
    {
        var post = await repo.GetPostByIdAsync(id);
        if (post == null)
        {
            return NotFound();
        }
        return post;
    }

    [HttpPost]
    public async Task<ActionResult<Post>> CreatePost(Post post)
    {
        repo.AddPost(post);
        if (await repo.SaveChangesAsync())
        {
            return CreatedAtAction("GetPost", new { id = post.Id }, post);
        }
        return BadRequest("Failed to create post.");
    }

    [HttpPut("{id:int}")]
    public async Task<ActionResult> UpdatePost(int id, Post post)
    {
        if( post.Id != id || !PostExists(id))
        {
            return BadRequest("Cannot update post. Id mismatch or post does not exist.");
        }

        repo.UpdatePost(post);
        if (await repo.SaveChangesAsync())
        {
            return NoContent();
        }
        return BadRequest("Failed to update post.");
    }

    [HttpDelete("{id:int}")]
    public async Task<ActionResult> DeletePost(int id)
    {
        var post = await repo.GetPostByIdAsync(id);
        if (post == null)
        {
            return NotFound();
        }
        repo.DeletePost(post);
       if (await repo.SaveChangesAsync())
        {
            return NoContent();
        }
        return BadRequest("Failed to delete post.");
    }


    #region Helper Methods
    private bool PostExists(int id)
    {
        return repo.PostExists(id);
    }
    #endregion

}
