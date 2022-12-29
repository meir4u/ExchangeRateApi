using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ExchangeRate.Application.Contract.Persistence
{
    public interface IGenericRepository<T> where T : class
    {
        IEnumerable<T> GetAll();
        void UpdateAll(IEnumerable<T> entity);
    }
}
