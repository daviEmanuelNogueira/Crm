namespace Crm.Domain.Entities;
public class StatusSubstatus
{
    public int Id { get; set; }
    public int StatusId { get; set; }
    public int SubstatusId { get; set; }
    public bool IsActivated { get; set; }

    public virtual Status Status { get; set; }
    public virtual Substatus Substatus { get; set; }
    public virtual ICollection<Atendimento> Atendimentos { get; set; }

}
