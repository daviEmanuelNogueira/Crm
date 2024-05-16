using Crm.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Crm.Infrastructure.Data;
public class Context : DbContext
{
   // public Context(DbContextOptions options) : base(options) { }

    public DbSet<Status> Status { get; set; }
    public DbSet<Substatus> Substatus { get; set; }
    public DbSet<StatusSubstatus> StatusSubstatus { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=fiapStoreEF;Integrated Security=True;TrustServerCertificate=True;");
    }
}
