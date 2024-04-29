using Crm.Domain.Entities;
using Crm.Domain.Interfaces;
using Crm.Infrastructure.Data;

namespace Crm.Infrastructure.Repositories;
public class StatusRepository : Repository<Status>, IStatusRepository, IRepository<Status>
{
    public StatusRepository(Context ctx) : base(ctx)
    {
    }
}
