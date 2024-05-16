using AutoMapper;
using Crm.Application.Requests;
using Crm.Domain.Entities;
using Crm.Domain.Interfaces;

namespace Crm.Application.UseCases.StatusSubstatusUseCase;
public class CreateStatusSubstatusUseCase
{
    private readonly IStatusRepository _statusRepository;
    private readonly ISubstatusRepository _substatusRepository;
    private readonly IStatusSubstatusRepository _statusSubstatusRepository;
    private readonly IMapper _mapper;

    public CreateStatusSubstatusUseCase(IStatusRepository statusRepository, ISubstatusRepository substatusRepository,
        IStatusSubstatusRepository statusSubstatusRepository, IMapper mapper)
    {
        _statusRepository = statusRepository;
        _substatusRepository = substatusRepository;
        _statusSubstatusRepository = statusSubstatusRepository;
        _mapper = mapper;
    }

    public void Execute(CreateStatusSubstatusRequestVM request)
    {
       Validations(request);
       _statusSubstatusRepository.Create(_mapper.Map<StatusSubstatus>(request));
    }

    private void Validations(CreateStatusSubstatusRequestVM request)
    {
        var status = _statusRepository.GetById(request.StatusId);
        var substatus = _substatusRepository.GetById(request.SubstatusId);

        if (status is null)
            throw new ArgumentException($"Status with ID {request.StatusId} not found.");

        if (substatus is null)
            throw new ArgumentException($"Substatus with ID {request.SubstatusId} not found.");
    }
}
