namespace Crm.Domain.Entities;
public class Atendimento
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Phone { get; set; } = string.Empty;
    public string Observations { get; set; } = string.Empty;
    public int StatusId { get; set; }
    public int SubstatusId { get; set; }
    public int MotivoId { get; set; }
    public DateTime CreatedDate { get; set; } = DateTime.UtcNow;

    public Status Status { get; set; } = new Status();
    public Substatus Substatus { get; set; } = new Substatus();
    public Motivo Motivo { get; set; } = new Motivo();


}
