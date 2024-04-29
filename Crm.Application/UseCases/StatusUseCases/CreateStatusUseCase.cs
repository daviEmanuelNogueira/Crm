using Crm.Application.DTOs.Status;
using Crm.Domain.Entities;
using Crm.Domain.Interfaces;

namespace Crm.Application.UseCases.StatusUseCases;
public class CreateStatusUseCase
{
    private readonly IStatusRepository _repository;

    public CreateStatusUseCase(IStatusRepository repository)
        => _repository = repository;

    public void Execute(CreateStatusDTO dTO)
    {
        Validations(dTO);

        var obj = new Status
        {
            Name = dTO.Name,
            IsActivated = dTO.IsActivated,
            IsFinisher = dTO.IsFinisher
        };

        _repository.Create(obj);
    }

    private void Validations(CreateStatusDTO dTO)
    {
        if (string.IsNullOrWhiteSpace(dTO.Name))
            throw new ArgumentException("Fill in the name field.");

        if (_repository.ExistsByName(dTO.Name))
            throw new ArgumentException("A status with the same name already exists.");
    }
}
