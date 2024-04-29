using Crm.Application.DTOs.Substatus;
using Crm.Domain.Entities;
using Crm.Domain.Interfaces;

namespace Crm.Application.UseCases.SubstatusUseCases;
public class CreateSubtatusUseCase
{
    private readonly ISubstatusRepository _repository;

    public CreateSubtatusUseCase(ISubstatusRepository repository)
        => _repository = repository;

    public void Execute(CreateSubstatusDTO dTO)
    {
        Validations(dTO);

        var obj = new Substatus
        {
            Name = dTO.Name,
            IsActivated = dTO.IsActivated
        };

        _repository.Create(obj);
    }

    private void Validations(CreateSubstatusDTO dTO)
    {
        if (string.IsNullOrWhiteSpace(dTO.Name))
            throw new ArgumentException("Fill in the name field.");

        if (_repository.ExistsByName(dTO.Name))
            throw new ArgumentException("A substatus with the same name already exists.");
    }
}
