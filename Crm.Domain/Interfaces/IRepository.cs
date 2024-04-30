using Crm.Domain.Entities;

namespace Crm.Domain.Interfaces;
public interface IRepository<T> where T : EBase
{
    void Create(T obj);
    bool ExistsByName(string name);
    List<T> GetAll();
    bool GetById(int id);
}
