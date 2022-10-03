using System.ComponentModel.DataAnnotations;

namespace Shared;

public class Post
{
    public int Id { get; set; }
    public User Owner { get; set; }
    public string Title { get; set; }
    public string Body { get; set; }
    public DateTime DateTime { get; set; }

    public Post(User owner, string title)
    {
        this.Owner = owner;
        this.Title = title;
    }
}