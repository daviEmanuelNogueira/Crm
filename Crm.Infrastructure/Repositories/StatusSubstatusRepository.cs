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

    public object? ObterId(int statusId)
    {
        throw new NotImplementedException();
    }

    public List<StatusSubstatus> ObterSubstatusComStatusId(int statusId)
    {
        var statusSubstatuses = _ctx.StatusSubstatus
               .Include(ss => ss.Status)
               .Include(ss => ss.Substatus)
               .Where(s => s.StatusId == statusId)
               .Select(ss => new StatusSubstatus
               {
                   Id = ss.Id,
                   StatusId = ss.StatusId,
                   SubstatusId = ss.SubstatusId,
                   IsActivated = ss.IsActivated,
                   Status = new Status
                   {
                       Id = ss.Status.Id,
                       Name = ss.Status.Name
                   },
                   Substatus = new Substatus
                   {
                       Id = ss.Substatus.Id,
                       Name = ss.Substatus.Name
                   }
               })
               .ToList();

        return statusSubstatuses;
    }

    public int ObterId(int statusId, int substatusId)
    {
        var statusSubstatus = _ctx.StatusSubstatus
            .FirstOrDefault(ss => ss.StatusId == statusId && ss.SubstatusId == substatusId);

        return statusSubstatus.Id;
    }
}
