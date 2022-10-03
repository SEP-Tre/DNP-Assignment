namespace Shared.DTOs;

public class PostCreationDto
{
    public string Title { get;  }
    public string Body { get;  }
    public string UserName { get; }

    public PostCreationDto(string title, string body, string userName)
    {
        this.Body = body;
        this.Title = title;
        this.UserName = userName;
    }
    
}