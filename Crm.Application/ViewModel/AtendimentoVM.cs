namespace Crm.Application.ViewModel;
public class AtendimentoVM
{
    public string Name { get; set; } = string.Empty;
    public string Phone { get; set; } = string.Empty;
    public string Observations { get; set; } = string.Empty;
    public int StatusSubstatusId { get; set; }
    public int MotivoId { get; set; }
}
