using CarMarket.Domain.Entity;
using CarMarket.Domain.Response;
using CarMarket.Domain.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CarMarket.Services.Interfaces
{
    public interface ICarService
    {
        Task<IBaseResponse<IEnumerable<Car>>> GetAllCars();

        Task<IBaseResponse<CarViewModel>> GetCar(int id);

        Task<IBaseResponse<CarViewModel>> CreateCar(CarViewModel carViewModel);

        Task<IBaseResponse<bool>> DeleteCar(int id);

        Task<IBaseResponse<Car>> GetCarByName(string name);

        Task<IBaseResponse<Car>> Edit(int id, CarViewModel model);
    }
}
