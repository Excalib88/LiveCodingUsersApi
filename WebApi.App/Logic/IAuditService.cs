namespace WebApi.App.Logic;

public interface IAuditService
{
    Task Log(string email);
}