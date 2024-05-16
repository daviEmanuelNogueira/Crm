using AutoMapper;
using Crm.Application.ViewModel;
using Crm.Domain.Entities;
using Crm.Domain.Interfaces;

namespace Crm.Application.UseCases.SubstatusUseCases;
public class CreateSubtatusUseCase
{
    private readonly ISubstatusRepository _repository;
    private readonly IMapper _mapper;

    public CreateSubtatusUseCase(ISubstatusRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public void Execute(SubstatusVM dTO)
    {
        Validations(dTO);

        _repository.Create(_mapper.Map<Substatus>(dTO));
    }

    private void Validations(SubstatusVM dTO)
    {
        if (string.IsNullOrWhiteSpace(dTO.Name))
            throw new ArgumentException("Fill in the name field.");

        if (_repository.ExistsByName(dTO.Name))
            throw new ArgumentException("A substatus with the same name already exists.");
    }
}
