
using Crm.Application.DTOs.SatusSubstatus;
using Crm.Domain.Interfaces;

namespace Crm.Application.UseCases.StatusSubstatusUseCase;
public class GetAllStatusSubstatusUseCase
{
    private readonly IStatusSubstatusRepository _statusSubstatusRepository;
    public GetAllStatusSubstatusUseCase(IStatusSubstatusRepository statusSubstatusRepository)
        => _statusSubstatusRepository = statusSubstatusRepository;

    public List<StatusSubstatusResponseDTO> Execute()
    {
        var statusSubstatusList = _statusSubstatusRepository.GetAll();

        var responseDTOList = statusSubstatusList.Select(statusSubstatus =>
            new StatusSubstatusResponseDTO
            {
                Id = statusSubstatus.Id,
                StatusName = statusSubstatus.Status.Name,
                SubstatusName = statusSubstatus.Substatus.Name
            }).ToList();

        return responseDTOList;
    }
}
