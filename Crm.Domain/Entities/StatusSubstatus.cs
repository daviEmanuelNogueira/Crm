namespace Crm.Domain.Entities;
public class StatusSubstatus
{
    public int Id { get; set; }
    public int StatusId { get; set; }
    public Status Status { get; set; } = new Status();

    public int SubstatusId { get; set; }
    public Substatus Substatus { get; set; } = new Substatus();
    public bool IsActivated { get; set; }

}
