using System.Security.Claims;
using Shared;
using Shared.DTOs;

namespace HttpClients.ClientInterfaces;

public interface IUserService
{
    public Task LoginAsync(UserCreationDto dto);
    public Task CreateAsync(UserCreationDto dto);
    public Task<ClaimsPrincipal> GetAuthAsync();

    public Action<ClaimsPrincipal> OnAuthStateChanged { get; set; }
}