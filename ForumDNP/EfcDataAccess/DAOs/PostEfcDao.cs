using System.Reflection.Metadata;
using Application.DaoInterfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Shared;

namespace EfcDataAccess.DAOs;

public class PostEfcDao : IPostDao
{
    private readonly ForumContext context;

    public PostEfcDao(ForumContext context)
    {
        this.context = context;
    }

    public async Task<Post> CreateAsync(Post post)
    {
        EntityEntry<Post> newPost = await context.Posts.AddAsync(post);
        await context.SaveChangesAsync();
        return newPost.Entity;
    }

    public async Task<Post?> GetByTitleAsync(string title)
    {
        IQueryable<Post> postsQuery = context.Posts.Include(post => post.Owner).AsQueryable();
        if (!string.IsNullOrEmpty(title))
        {
            postsQuery = postsQuery.Where(p => p.Title.ToLower().Equals(title.ToLower()));
        }

        Post? post = await postsQuery.FirstOrDefaultAsync();
        return post;
    }

    public Task<IEnumerable<string>> GetAllByTitleAsync()
    {
        IEnumerable<Post> posts = context.Posts.AsEnumerable();
        List<string> titles = new List<string>();
        foreach (Post post in posts)
        {
            titles.Add(post.Title);
        }
        //TODO error maybe here
        return Task.FromResult(titles.AsEnumerable());
    }
}