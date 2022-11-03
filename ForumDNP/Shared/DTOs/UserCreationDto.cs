namespace Shared.DTOs;

public class UserCreationDto
{
    public string UserName { get; set; }
    public string Password { get; set; }

    public UserCreationDto(string userName, string password)
    {
        UserName = userName;
        Password = password;
    }
}