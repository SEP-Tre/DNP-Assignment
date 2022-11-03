using Shared;
using Shared.DTOs;

namespace HttpClients.ClientInterfaces;

public interface IPostService
{
    Task CreateAsync(PostCreationDto dto);
    Task<ICollection<string>> GetTitlesAsync();
    Task<Post> GetByTitleAsync(string title);
}