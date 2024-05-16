namespace Crm.Domain.Entities;
public class Status : EBase
{
    
    public bool IsFinisher { get; set; }
    public virtual ICollection<StatusSubstatus> StatusSubstatuses { get; set; }
}
