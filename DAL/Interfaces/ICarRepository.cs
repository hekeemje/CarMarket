using CarMarket.Domain.Entity;
using System.Threading.Tasks;

namespace CarMarket.DAL.Interfaces
{
    public interface ICarRepository : IBaseRepository<Car>
    {
        Task<Car> GetByName(string name);
    }
}
