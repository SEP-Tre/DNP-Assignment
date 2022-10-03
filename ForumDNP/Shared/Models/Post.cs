using System.ComponentModel.DataAnnotations;

namespace Shared;

public class Post
{
    public User owner { get; set; }
    public string title { get; set; }
    public string body { get; set; }
    public DateTime DateTime { get; set; }

    public Post(User owner, string title)
    {
        this.owner = owner;
        this.title = title;
    }
}