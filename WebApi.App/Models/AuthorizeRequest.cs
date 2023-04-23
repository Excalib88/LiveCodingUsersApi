namespace WebApi.App.Models;

public class AuthorizeRequest
{
    public string Email { get; set; } = null!;
    public string Password { get; set; } = null!;
}