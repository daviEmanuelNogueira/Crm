using Crm.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Crm.Infrastructure.Data;
public class Context : DbContext
{
    public DbSet<Status> Status { get; set; }
    public DbSet<Substatus> Substatus { get; set; }
    public DbSet<StatusSubstatus> StatusSubstatus { get; set; }
    public DbSet<Motivo> Motivos { get; set; }
    public DbSet<Atendimento> Atendimentos { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=crm_tc4_db;Integrated Security=True;TrustServerCertificate=True;");
    }

    //public Context(DbContextOptions<Context> options) : base(options)
    //{
    //}
}
