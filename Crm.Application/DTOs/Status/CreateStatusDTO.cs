namespace Crm.Application.DTOs.Status;
public class CreateStatusDTO
{
    public string Name { get; set; } = string.Empty;
    public bool IsActivated { get; set; }
    public bool IsFinisher { get; set; }
}
