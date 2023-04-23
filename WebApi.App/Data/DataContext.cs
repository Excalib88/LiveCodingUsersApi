using Microsoft.EntityFrameworkCore;
using WebApi.App.Data.Entities;

namespace WebApi.App.Data;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {
    }

    public DbSet<Audit> Audits { get; set; } = null!;
}