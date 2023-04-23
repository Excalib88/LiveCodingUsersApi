using WebApi.App.Data;
using WebApi.App.Data.Entities;

namespace WebApi.App.Logic;

public class AuditService : IAuditService
{
    private readonly DataContext _context;

    public AuditService(DataContext context)
    {
        _context = context;
    }

    public async Task Log(string email)
    {
        await _context.Audits.AddAsync(new Audit
        {
            Email = email
        });

        await _context.SaveChangesAsync();
    }
}