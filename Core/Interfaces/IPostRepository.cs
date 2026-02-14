using Core.Entities;
namespace Core.Interfaces;

public interface IPostRepository
{
    Task<IReadOnlyList<Post>> GetPostsAsync();
    Task<Post?> GetPostByIdAsync(int id);
    void AddPost(Post post);
    void UpdatePost(Post post);
    void DeletePost(Post post);

    bool PostExists(int id);
    Task<bool> SaveChangesAsync();
}
