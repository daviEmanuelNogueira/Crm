namespace Crm.Application.ViewModel;
public class StatusSubstatusResponseVM
{
    public int Id { get; set; }
    public string StatusName { get; set; } = string.Empty;
    public string SubstatusName { get; set; } = string.Empty;
    public bool IsActivated { get; set; }
}
