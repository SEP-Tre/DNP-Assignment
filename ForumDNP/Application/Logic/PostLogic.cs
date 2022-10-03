using Application.DaoInterfaces;
using Application.LogicInterfaces;
using Shared;
using Shared.DTOs;

namespace Application.Logic;

public class PostLogic:IPostLogic

{
    private readonly IPostDao postDao;
    private readonly IUserDao userDao;

    public PostLogic(IPostDao postDao, IUserDao userDao)
    {
        this.postDao = postDao;
        this.userDao = userDao;
    }

    public async Task<Post> CreateAsync(PostCreationDto dto)
    {
        User? existingUser = await userDao.GetByUsernameAsync(dto.UserName);
        if (existingUser == null) throw new Exception("Given user does not exist.");

        Post? existingPost = await postDao.GetByTitleAsync(dto.Title);
        if (existingPost != null) throw new Exception("Given title is already taken.");
        
        ValidateData(dto);
        
        Post newPost = new Post(existingUser, dto.Title)
        {
            Body = dto.Body
        };

        Post created = await postDao.CreateAsync(newPost);

        return created;

    }

    public async Task<Post> GetByTitleAsync(string title)
    {
        if (String.IsNullOrEmpty(title))
        {
            throw new Exception("Title cannot be empty.");
        }
        Post? existingPost = await postDao.GetByTitleAsync(title);
        if (existingPost == null) throw new Exception("Given title does not exist.");
        return existingPost;
    }

    public Task<IEnumerable<string>> GetAllTitlesAsync()
    {
        return postDao.GetAllByTitleAsync();
    }


    private static void ValidateData(PostCreationDto dto)
    {
        string username = dto.UserName;
        string title = dto.Title;
        string body = dto.Body;
        if (String.IsNullOrEmpty(title) || String.IsNullOrEmpty(body)|| String.IsNullOrEmpty(username))
        {
            throw new Exception("The fields cannot be empty!");
        }

        if (title.Length is < 10 or > 100)
        {
            throw new Exception("The title has to be between 10 and 100 characters.");
        }

        if (body.Length is < 100 or > 1000)
        {
            throw new Exception("The body has to be between 100 and 1000 characters.");
        }
    }
}