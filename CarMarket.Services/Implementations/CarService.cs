using CarMarket.DAL.Interfaces;
using CarMarket.Domain.Entity;
using CarMarket.Domain.Enum;
using CarMarket.Domain.Response;
using CarMarket.Domain.ViewModels;
using CarMarket.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarMarket.Services.Implementations
{
    public class CarService : ICarService
    {
        private readonly ICarRepository _carRepository;

        public CarService(ICarRepository carRepository)
        {
            _carRepository = carRepository;
        }

        public async Task<IBaseResponse<CarViewModel>> GetCar(int id)
        {
            var baseResponse = new BaseResponse<CarViewModel>();

            try
            {
                var car = await _carRepository.Get(id);

                if (car == null)
                {
                    baseResponse.Description = "Car not found.";
                    baseResponse.StatusCode = StatusCode.CarNotFound;

                    return baseResponse;
                }

                var data = new CarViewModel()
                {
                    CarId = car.CarId,
                    CarName = car.CarName,
                    Price = car.Price,
                    DateCreate = car.DateCreate,
                    Description = car.Description,
                    Type = car.Type.ToString(),
                    Speed = car.Speed,
                    Model = car.Model,
                    CarImage = car.CarImage
                };

                baseResponse.Data = data;
                baseResponse.StatusCode = StatusCode.OK;
                return baseResponse;
            }
            catch (Exception ex)
            {
                return new BaseResponse<CarViewModel>()
                {
                    Description = $"[GetCar] : {ex.Message}",
                    StatusCode = StatusCode.InternalServerError
                };
            }
        }

        public async Task<IBaseResponse<Car>> GetCarByName(string name)
        {
            var baseResponse = new BaseResponse<Car>();

            try
            {
                var car = await _carRepository.GetByName(name);

                if (car == null)
                {
                    baseResponse.Description = "Car not found.";
                    baseResponse.StatusCode = StatusCode.CarNotFound;

                    return baseResponse;
                }

                baseResponse.Data = car;
                return baseResponse;
            }
            catch (Exception ex)
            {
                return new BaseResponse<Car>()
                {
                    Description = $"[GetCarByName] : {ex.Message}",
                    StatusCode = StatusCode.InternalServerError
                };
            }
        }

        public async Task<IBaseResponse<Car>> Edit(int id, CarViewModel model)
        {
            var baseResponse = new BaseResponse<Car>();
            try
            {
                var car = await _carRepository.Get(id);
                if (car == null)
                {
                    baseResponse.StatusCode = StatusCode.CarNotFound;
                    baseResponse.Description = "Car not found";
                    return baseResponse;
                }

                car.Description = model.Description;
                car.Model = model.Model;
                car.Price = model.Price;
                car.Speed = model.Speed;
                car.DateCreate = model.DateCreate;
                car.CarName = model.CarName;

                await _carRepository.Update(car);

                return baseResponse;
            }
            catch (Exception ex)
            {
                return new BaseResponse<Car>()
                {
                    Description = $"[Edit] : {ex.Message}",
                    StatusCode = StatusCode.InternalServerError
                };
            }
        }

        public async Task<IBaseResponse<IEnumerable<Car>>> GetAllCars()
        {
            var baseResponse = new BaseResponse<IEnumerable<Car>>();

            try
            {
                var cars = await _carRepository.Select();

                if (cars.Count == 0)
                {
                    baseResponse.Description = "0 elements founded.";
                    baseResponse.StatusCode = StatusCode.OK;
                    return baseResponse;
                }

                baseResponse.Data = cars;
                baseResponse.StatusCode = StatusCode.OK;

                return baseResponse;
            }
            catch (Exception ex)
            {
                return new BaseResponse<IEnumerable<Car>>()
                {
                    Description = $"[GetCars] : {ex.Message}",
                    StatusCode = StatusCode.InternalServerError
                };
            }
        }

        public async Task<IBaseResponse<CarViewModel>> CreateCar(CarViewModel carViewModel)
        {
            var baseResponse = new BaseResponse<CarViewModel>();

            try
            {
                var car = new Car()
                {
                    CarName = carViewModel.CarName,
                    Description = carViewModel.Description,
                    Model = carViewModel.Model,
                    Speed = carViewModel.Speed,
                    Price = carViewModel.Price,
                    DateCreate = carViewModel.DateCreate,
                    Type = (TypeCar)Convert.ToInt32(carViewModel.Type),
                    CarImage = carViewModel.CarImage
                };

                await _carRepository.Create(car);
            }
            catch (Exception ex)
            {
                return new BaseResponse<CarViewModel>()
                {
                    Description = $"[CreateCar] : {ex.Message}",
                    StatusCode = StatusCode.InternalServerError
                };
            }

            return baseResponse;
        }

        public async Task<IBaseResponse<bool>> DeleteCar(int id)
        {
            var baseResponse = new BaseResponse<bool>()
            {
                Data = true
            };

            try
            {
                var car = await _carRepository.Get(id);

                if (car == null)
                {
                    baseResponse.Description = "Car not found.";
                    baseResponse.StatusCode = StatusCode.CarNotFound;
                    baseResponse.Data = false;

                    return baseResponse;
                }

                await _carRepository.Delete(car);

                return baseResponse;
            }
            catch (Exception ex)
            {
                return new BaseResponse<bool>()
                {
                    Description = $"[DeleteCar] : {ex.Message}",
                    StatusCode = StatusCode.InternalServerError
                };
            }
        }
    }
}
