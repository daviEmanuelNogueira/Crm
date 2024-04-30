using Crm.Application.Requests;
using Crm.Domain.Entities;
using Crm.Domain.Interfaces;

namespace Crm.Application.UseCases.StatusSubstatusUseCase;
public class CreateStatusSubstatusUseCase
{
    private readonly IStatusRepository _statusRepository;
    private readonly ISubstatusRepository _substatusRepository;
    private readonly IStatusSubstatusRepository _statusSubstatusRepository;

    public CreateStatusSubstatusUseCase(IStatusRepository statusRepository, ISubstatusRepository substatusRepository, IStatusSubstatusRepository statusSubstatusRepository)
    {
        _statusRepository = statusRepository;
        _substatusRepository = substatusRepository;
        _statusSubstatusRepository = statusSubstatusRepository;
    }

    public void Execute(CreateStatusSubstatusRequest request)
    {
        Validations(request);

        var statusSubstatus = new StatusSubstatus
        {
            StatusId = request.StatusId,
            SubstatusId = request.SubstatusId,
            IsActivated = request.IsActivated
        };

        _statusSubstatusRepository.Create(statusSubstatus);
    }

    private void Validations(CreateStatusSubstatusRequest request)
    {
        var status = _statusRepository.GetById(request.StatusId);
        if (!status)
            throw new ArgumentException($"Status with ID {request.StatusId} not found.");

        var substatus = _substatusRepository.GetById(request.SubstatusId);
        if (!substatus)
            throw new ArgumentException($"Substatus with ID {request.SubstatusId} not found.");
    }
}
