using Core.Entities;
using Core.Interfaces;
using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Core.Specifications;

namespace API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PostsController(IGenericRepository<Post> repo) : ControllerBase
{
    [HttpGet]  
    public async Task<ActionResult<IReadOnlyList<Post>>> GetPosts(string ?type, string ?author, string ?sort)
    {
        var spec = new PostSpecification(type, author, sort); 
        var posts = await repo.ListAsync(spec);
            
        return Ok(posts);
    }

    [HttpGet("{id:int}")] // api/posts/3
    public async Task<ActionResult<Post>> GetPost(int id)
    {
        var post = await repo.GetByIdAsync(id);
        if (post == null)
        {
            return NotFound();
        }
        return post;
    }

    [HttpPost]
    public async Task<ActionResult<Post>> CreatePost(Post post)
    {
        repo.Add(post);
        if (await repo.SaveAllAsync())
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

        repo.Update(post);
        if (await repo.SaveAllAsync())
        {
            return NoContent();
        }
        return BadRequest("Failed to update post.");
    }

    [HttpDelete("{id:int}")]
    public async Task<ActionResult> DeletePost(int id)
    {
        var post = await repo.GetByIdAsync(id);
        if (post == null)
        {
            return NotFound();
        }
        repo.Remove(post);
       if (await repo.SaveAllAsync())
        {
            return NoContent();
        }
        return BadRequest("Failed to delete post.");
    }

    [HttpGet("types")]
    public async Task<ActionResult<IReadOnlyList<string>>> GetTypes()
    {
        var spec = new TypeListSpecification();
        return Ok(await repo.ListAsync(spec));  
    }

    [HttpGet("authors")]
    public async Task<ActionResult<IReadOnlyList<string>>> GetAuthors()
    {
        var spec = new AuthorListSpecification();
        return Ok(await repo.ListAsync(spec));
    }

    #region Helper Methods
    private bool PostExists(int id)
    {
        return repo.Exists(id);
    }
    #endregion

}