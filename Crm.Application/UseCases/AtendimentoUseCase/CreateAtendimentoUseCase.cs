using AutoMapper;
using Crm.Application.ViewModel;
using Crm.Domain.Entities;
using Crm.Domain.Interfaces;

namespace Crm.Application.UseCases.AtendimentoUseCase;
public class CreateAtendimentoUseCase
{
    private readonly IStatusSubstatusRepository _statusSubstatusRepository;
    private readonly IMotivoRepository _motivoRepository;
    private readonly IAtendimentoRepository _atendimentoRepository;
    private IMapper _mapper;

    public CreateAtendimentoUseCase(IStatusSubstatusRepository statusSubstatusRepository, IMotivoRepository motivoRepository, IMapper mapper, IAtendimentoRepository atendimentoRepository)
    {
        _statusSubstatusRepository = statusSubstatusRepository;
        _motivoRepository = motivoRepository;
        _mapper = mapper;
        _atendimentoRepository = atendimentoRepository;
    }

    public void Execute(AtendimentoVM atendimento)
    {
        Validations(atendimento);
        _atendimentoRepository.Cadastrar(_mapper.Map<Atendimento>(atendimento));
    }

    private void Validations(AtendimentoVM atendimento)
    {
        if (string.IsNullOrWhiteSpace(atendimento.Name))
            throw new ArgumentException($"Name is required.");

        if (string.IsNullOrWhiteSpace(atendimento.Phone))
            throw new ArgumentException($"Phone is required.");

        if (_motivoRepository.GetById(atendimento.MotivoId) is null)
            throw new ArgumentException($"Motivo is invalid.");

        if (_statusSubstatusRepository.GetById(atendimento.StatusSubstatusId) is null)
            throw new ArgumentException($"Status Substatus is invalid.");

    }
}
