using WebApi.App.Extensions;
using WebApi.App.Models;

namespace WebApi.App.Logic;

public class UserService : IUserService
{
    private readonly IUserParser _userParser;

    public UserService(IUserParser userParser)
    {
        _userParser = userParser;
    }

    public async Task<List<UserModel>> GetAll(AuthorizeRequest authorizeRequest)
    {
        var users = await _userParser.Parse();
        var currentUser = users.FirstOrDefault(x => x.Email == authorizeRequest.Email);
        
        if (currentUser == null || currentUser.Phone != authorizeRequest.Password)
        {
            return users.BulkMask();
        }

        users.Remove(currentUser);
        users = users.BulkMask();
        users.Add(currentUser);
        
        return users;
    }
}