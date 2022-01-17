using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Shared.Repositories
{
    public interface IRepository<T>
    {
        IQueryable<T> GetAll();

        Task Add(T obj);
        
    }
}