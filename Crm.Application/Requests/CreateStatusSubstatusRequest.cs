namespace Crm.Application.Requests;
public class CreateStatusSubstatusRequest
{
    public int StatusId { get; set; }
    public int SubstatusId { get; set; }
    public bool IsActivated { get; set; }
}
