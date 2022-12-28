using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ExchangeRate.Application.Contract.Persistence
{
    public interface IGenericRepository<T> where T : class
    {
        Task<T> Get(T entity);
        Task<IReadOnlyList<T>> GetAll();
        Task<bool> Exsits(T entity);
        Task<T> Add(T entity);
        Task<T> Update(T entity);
        Task<T> Delete(T entity);
    }
}
