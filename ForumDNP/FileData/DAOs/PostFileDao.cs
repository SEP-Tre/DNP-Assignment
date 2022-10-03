using System.Runtime.CompilerServices;
using Application.DaoInterfaces;
using Shared;

namespace FileData.DAOs;

public class PostFileDao: IPostDao
{
    private readonly FileContext context;

    public PostFileDao(FileContext context)
    {
        this.context = context;
    }

    public Task<Post> CreateAsync(Post post)
    {
        int postId = 1;
        if (context.Posts.Any())
        {
            postId = context.Posts.Max(p => p.Id);
            postId++;
        }

        post.Id = postId;
        post.DateTime = DateTime.Now; 
        
        context.Posts.Add(post);
        context.SaveChanges();

        return Task.FromResult(post);
    }

    public Task<Post?> GetByTitleAsync(string title)
    {
        Post? existing = context.Posts.FirstOrDefault
            (p => p.Title.Equals(title, StringComparison.OrdinalIgnoreCase));
        return Task.FromResult(existing);
    }

    public Task<IEnumerable<string>> GetAllByTitleAsync()
    {
        var list = new List<string>();
        foreach (var contextPost in context.Posts)
        {
            list.Add(contextPost.Title);
        }

        return Task.FromResult(list.AsEnumerable());
    }
}