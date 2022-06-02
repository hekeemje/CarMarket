using System.Collections.Generic;
using System.Threading.Tasks;

namespace CarMarket.DAL.Interfaces
{
    public interface IBaseRepository<T>
    {
        public Task<bool> Create(T entity);
        public Task<T> Get(int id);
        public Task<List<T>> Select();
        public Task<bool> Delete(T entity);
        Task<T> Update(T entity);
    }
}
