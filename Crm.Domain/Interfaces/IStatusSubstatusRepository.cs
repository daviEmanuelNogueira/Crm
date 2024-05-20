using Crm.Domain.Entities;

namespace Crm.Domain.Interfaces;
public interface IStatusSubstatusRepository
{
    void Create(StatusSubstatus statusSubstatus);
    List<StatusSubstatus> GetAll();
    StatusSubstatus? GetById(int id);
    int ObterId(int statusId, int substatusId);
    List<StatusSubstatus> ObterSubstatusComStatusId(int statusId);
}
