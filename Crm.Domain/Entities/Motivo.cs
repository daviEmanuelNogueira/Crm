namespace Crm.Domain.Entities;
public class Motivo : EBase
{
    public virtual ICollection<Atendimento> Atendimentos { get; set; }
}
