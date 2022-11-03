using Shared.DTOs;

namespace Shared;

public class User
{
    public int Id { get; set; }
    public string UserName { get; set; }
    public string Password { get; set; }

    public User(UserCreationDto dto)
    {
        UserName = dto.UserName;
        Password = dto.Password;
    }

    public User()
    {
    }
}