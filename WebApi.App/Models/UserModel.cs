namespace WebApi.App.Models;

public class UserModel
{
    public long Id { get; set; }
    public string Username { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string Phone { get; set; } = null!;
    public string Website { get; set; } = null!;
    public CompanyModel Company { get; set; } = null!;
}