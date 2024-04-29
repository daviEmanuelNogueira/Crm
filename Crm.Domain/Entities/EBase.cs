namespace Crm.Domain.Entities;
public class EBase
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public bool IsActivated { get; set; }
}
