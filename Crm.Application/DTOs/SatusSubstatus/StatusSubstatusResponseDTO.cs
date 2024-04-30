namespace Crm.Application.DTOs.SatusSubstatus;
public class StatusSubstatusResponseDTO
{
    public int Id { get; set; }
    public string StatusName { get; set; } = string.Empty;
    public string SubstatusName { get; set; } = string.Empty;
    public bool IsActivated { get; set; }
}
