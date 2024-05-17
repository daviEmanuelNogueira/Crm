using Crm.Application.ViewModel;

namespace Crm.Application.UseCases.AtendimentoUseCase;
public class CreateAtendimentoUseCase
{
    public void Execute(AtendimentoVM atendimento)
    {
        Validations(atendimento);
    }

    private void Validations(AtendimentoVM atendimento)
    {
        if (atendimento.Name is null)
            throw new ArgumentException($"Name is required.");

        if (atendimento.Phone is null)
            throw new ArgumentException($"Phone is required.");
    }
}
