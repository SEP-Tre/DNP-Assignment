using Shared;

namespace Application.DaoInterfaces;

public interface IPostDao
{
    Task<Post> CreateAsync(Post post);
    Task<Post?> GetByTitleAsync(string title);
    Task<IEnumerable<string>> GetAllByTitleAsync();
}