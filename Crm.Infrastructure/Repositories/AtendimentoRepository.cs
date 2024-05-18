using Crm.Domain.Entities;
using Crm.Domain.Interfaces;
using Crm.Infrastructure.Data;

namespace Crm.Infrastructure.Repositories;
public class AtendimentoRepository : IAtendimentoRepository
{
    protected Context _context;

    public AtendimentoRepository(Context context)
    {
        _context = context;
    }

    public void Cadastrar(Atendimento atendimento)
    {
        _context.Atendimentos.Add(atendimento);
        _context.SaveChanges();
    }
}
