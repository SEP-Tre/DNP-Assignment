using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using Shared.DTOs;

namespace Shared;

public class User
{
    [Key]
    public int Id { get; set; }
    public string UserName { get; set; }
    public string Password { get; set; }
    
    [JsonIgnore]
    public ICollection<Post> Posts { get; set; }

    public User(UserCreationDto dto)
    {
        UserName = dto.UserName;
        Password = dto.Password;
    }

    public User()
    {
    }
}