namespace Crm.Domain.Entities;
public class Substatus : EBase
{
    public virtual ICollection<StatusSubstatus> StatusSubstatuses { get; set; }
    public virtual ICollection<Atendimento> Atendimentos { get; set; }
}
