using Crm.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Crm.Infrastructure.Data;
public class Context : DbContext
{
    public DbSet<Status> Status { get; set; }
    public DbSet<Substatus> Substatus { get; set; }
    public DbSet<StatusSubstatus> StatusSubstatus { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseInMemoryDatabase(databaseName: "InMemory_Database");
    } 
}
