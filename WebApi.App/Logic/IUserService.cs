using WebApi.App.Models;

namespace WebApi.App.Logic;

public interface IUserService
{
    Task<List<UserModel>> GetAll(AuthorizeRequest request);
}