namespace Crm.Domain.Entities;
public class Atendimento
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Phone { get; set; } = string.Empty;
    public string Observations { get; set; } = string.Empty;
    public int StatusSubstatusId { get; set; }
    public int MotivoId { get; set; }
    public DateTime CreatedDate { get; set; } = DateTime.UtcNow;

    public virtual StatusSubstatus StatusSubstatus { get; set; }
    public virtual Motivo Motivo { get; set; }


}
