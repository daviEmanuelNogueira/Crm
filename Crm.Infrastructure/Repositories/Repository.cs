using Crm.Domain.Entities;
using Crm.Domain.Interfaces;
using Crm.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Crm.Infrastructure.Repositories;
public class Repository<T> : IRepository<T> where T : EBase
{
    protected Context _ctx;
    protected DbSet<T> _dbSet;

    public Repository(Context ctx)
    {
        _ctx = ctx;
        _dbSet = _ctx.Set<T>();
    }

    public void Create(T obj)
    {
        _dbSet.Add(obj);
        _ctx.SaveChanges();
    }

    public bool ExistsByName(string name)
    {
        return _dbSet.Any(o => o.Name == name);
    }

    public List<T> GetAll()
    {
        return _dbSet.ToList();
    }

    public bool GetById(int id)
    {
        return _dbSet.Any(o => o.Id == id);
    }
}
