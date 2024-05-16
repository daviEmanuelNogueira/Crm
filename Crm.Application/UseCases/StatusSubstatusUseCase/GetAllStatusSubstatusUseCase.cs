
using AutoMapper;
using Crm.Application.ViewModel;
using Crm.Domain.Interfaces;

namespace Crm.Application.UseCases.StatusSubstatusUseCase;
public class GetAllStatusSubstatusUseCase
{
    private readonly IStatusSubstatusRepository _statusSubstatusRepository;
    private readonly IMapper _mapper;
    public GetAllStatusSubstatusUseCase(IStatusSubstatusRepository statusSubstatusRepository, IMapper mapper)
    {
        _statusSubstatusRepository = statusSubstatusRepository;
        _mapper = mapper;
    }

    public List<StatusSubstatusResponseVM> Execute()
    {
        return _mapper.Map<List<StatusSubstatusResponseVM>>(_statusSubstatusRepository.GetAll());
      
    }
}
