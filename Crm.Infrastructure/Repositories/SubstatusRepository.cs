using Crm.Domain.Entities;
using Crm.Domain.Interfaces;
using Crm.Infrastructure.Data;

namespace Crm.Infrastructure.Repositories;
public class SubstatusRepository : Repository<Substatus>, ISubstatusRepository, IRepository<Substatus>
{
    public SubstatusRepository(Context ctx) : base(ctx)
    {
    }
}
