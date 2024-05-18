using Crm.Domain.Entities;
using Crm.Domain.Interfaces;
using Crm.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Crm.Infrastructure.Repositories;
public class StatusSubstatusRepository : IStatusSubstatusRepository
{
    protected Context _ctx;
    public StatusSubstatusRepository(Context ctx)
        =>_ctx = ctx;

    public void Create(StatusSubstatus statusSubstatus)
    {

        _ctx.StatusSubstatus.Add(statusSubstatus);
        _ctx.SaveChanges();
    }

    public List<StatusSubstatus> GetAll()
    {
        return _ctx.StatusSubstatus.Include(ss => ss.Status).Include(ss => ss.Substatus).ToList();
    }

    public StatusSubstatus? GetById(int id)
    {
        return _ctx.StatusSubstatus.FirstOrDefault(s => s.Id == id);
    }
}
