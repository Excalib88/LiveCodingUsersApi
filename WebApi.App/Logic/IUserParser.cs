using WebApi.App.Models;

namespace WebApi.App.Logic;

public interface IUserParser
{
    Task<List<UserModel>> Parse();
}