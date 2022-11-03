using Application.DaoInterfaces;
using Application.LogicInterfaces;
using Shared;
using Shared.DTOs;

namespace Application.Logic;

public class UserLogic : IUserLogic
{
    private readonly IUserDao userDao;

    public UserLogic(IUserDao userDao)
    {
        this.userDao = userDao;
    }

    public async Task<User> CreateAsync(UserCreationDto userToCreate)
    {
        User? exsisting = await userDao.GetByUsernameAsync(userToCreate.UserName);

        if (exsisting != null)
        {
            throw new Exception("Such user already exists.");
        }
        ValidateData(userToCreate);
        User newUser = new User(userToCreate);
        

        User created = await userDao.CreateAsync(newUser);

        return created;
    }

    public async Task LoginAsync(UserCreationDto dto)
    {
        User? exsisting = await userDao.GetByUsernameAsync(dto.UserName);

        if (exsisting == null)
        {
            throw new Exception("Such user already exists.");
        }
    }


    private static void ValidateData(UserCreationDto dto)
    {
        string username = dto.UserName;
        string password = dto.Password;

        if (String.IsNullOrEmpty(username) || String.IsNullOrEmpty(password))
        {
            throw new Exception("Username or password cannot be empty.");
        }

        if (username.Length <= 6)
        {
            throw new Exception("Username has to have more than 6 characters.");
        }

        if (password.ToLower().Contains(username.ToLower()))
        {
            throw new Exception("Password and username cannot be the same");
        }

        if (password.Length <= 6)
        {
            throw new Exception("Password has to have more than 6 characters.");
        }
    }

}
