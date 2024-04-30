using Crm.Domain.Entities;

namespace Crm.Domain.Interfaces;
public interface IStatusSubstatusRepository
{
    void Create(StatusSubstatus statusSubstatus);
    List<StatusSubstatus> GetAll();
}
