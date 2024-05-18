using Crm.Domain.Entities;

namespace Crm.Domain.Interfaces;
public interface IAtendimentoRepository
{
    void Cadastrar(Atendimento atendimento);
}
