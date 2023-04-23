using WebApi.App.Models;

namespace WebApi.App.Extensions;

public static class MaskExtensions
{
    public static UserModel Mask(this UserModel user)
    {
        var maskChars = "*******";
        user.Phone = maskChars;
        user.Username = maskChars;
        user.Website = maskChars;

        user.Company.Bs = maskChars;
        user.Company.Name = maskChars;
        user.Company.CatchPhrase = maskChars;

        return user;
    }

    public static List<UserModel> BulkMask(this List<UserModel> users)
    {
        return users.Select(x => x.Mask()).ToList();
    }
}