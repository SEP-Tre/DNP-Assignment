using Application.DaoInterfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Shared;

namespace EfcDataAccess.DAOs;

public class UserEfcDao : IUserDao
{
    private readonly ForumContext context;

    public UserEfcDao(ForumContext context)
    {
        this.context = context;
    }

    public async Task<User> CreateAsync(User user)
    {
        EntityEntry<User> newUser = await context.Users.AddAsync(user);
        await context.SaveChangesAsync();
        return newUser.Entity;
    }

    public async Task<User?> GetByUsernameAsync(string userName)
    {
        User? existing = await context.Users.FirstOrDefaultAsync
            (u => u.UserName.ToLower().Equals(userName.ToLower()));
        return existing;
    }
}