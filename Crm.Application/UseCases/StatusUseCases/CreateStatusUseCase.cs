using AutoMapper;
using Crm.Application.ViewModel;
using Crm.Domain.Entities;
using Crm.Domain.Interfaces;

namespace Crm.Application.UseCases.StatusUseCases;
public class CreateStatusUseCase
{
    private readonly IStatusRepository _repository;
    private readonly IMapper _mapper;

    public CreateStatusUseCase(IStatusRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public void Execute(StatusVM dTO)
    {
        Validations(dTO);
        _repository.Create(_mapper.Map<Status>(dTO));
    }

    private void Validations(StatusVM dTO)
    {
        if (string.IsNullOrWhiteSpace(dTO.Name))
            throw new ArgumentException("Fill in the name field.");

        if (_repository.ExistsByName(dTO.Name))
            throw new ArgumentException("A status with the same name already exists.");
    }
}
