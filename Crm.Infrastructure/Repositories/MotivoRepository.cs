using Crm.Domain.Entities;
using Crm.Domain.Interfaces;
using Crm.Infrastructure.Data;

namespace Crm.Infrastructure.Repositories;
public class MotivoRepository : Repository<Motivo>, IMotivoRepository, IRepository<Motivo>
{
    public MotivoRepository(Context ctx) : base(ctx)
    {
    }
}
