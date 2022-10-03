using Shared;
using Shared.DTOs;

namespace Application.LogicInterfaces;

public interface IPostLogic
{
    Task<Post> CreateAsync(PostCreationDto dto);
    Task<Post> GetByTitleAsync(string title);

    Task<IEnumerable<string>> GetAllTitlesAsync();
}