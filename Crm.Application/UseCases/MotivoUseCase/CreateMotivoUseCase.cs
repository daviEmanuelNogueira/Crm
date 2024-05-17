using AutoMapper;
using Crm.Application.ViewModel.Motivo;
using Crm.Domain.Entities;
using Crm.Domain.Interfaces;

namespace Crm.Application.UseCases.MotivoUseCase;
public class CreateMotivoUseCase
{
    private readonly IMotivoRepository _repository;
    private readonly IMapper _mapper;

    public CreateMotivoUseCase(IMotivoRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public void Execute(MotivoVM dTO)
    {
        Validations(dTO);
        _repository.Create(_mapper.Map<Motivo>(dTO));
    }

    private void Validations(MotivoVM dTO)
    {
        if (string.IsNullOrWhiteSpace(dTO.Name))
            throw new ArgumentException("Fill in the name field.");

        if (_repository.ExistsByName(dTO.Name))
            throw new ArgumentException("A motivo with the same name already exists.");
    }
}
