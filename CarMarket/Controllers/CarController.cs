using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using CarMarket.Domain;
using CarMarket.Domain.Enum;
using CarMarket.Domain.ViewModels;
using CarMarket.Services.Interfaces;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace CarMarket.Controllers
{
    public class CarController : Controller
    {
        private readonly ICarService _carService;

        public CarController(ICarService carService)
        {
            _carService = carService;
        }

        [HttpGet]
        public async Task<IActionResult> GetCars()
        {

            //var car = new CarViewModel()
            //{
            //    CarName = "Kia K5",
            //    Description = "Kia K5 Sportage",
            //    Model = "KIA",
            //    Speed = 200,
            //    Price = 29000,
            //    DateCreate = DateTime.Now,
            //    Type = 2.ToString(),
            //    CarImage = "https://cdn.riastatic.com/photosnew/auto/photo/Kia_K5__443279143f.jpg"
            //};

            //await _carService.CreateCar(car);

            var response = await _carService.GetAllCars();

            if (response.StatusCode == Domain.Enum.StatusCode.OK)
            {
                return View(response.Data.ToList());
            }

            return RedirectToAction("Error");
        }

        [HttpGet]
        public async Task<IActionResult> GetCar(int id)
        {
            var response = await _carService.GetCar(id);

            if (response.StatusCode == Domain.Enum.StatusCode.OK)
            {
                return View(response.Data);
            }

            return RedirectToAction("Error");
        }

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int id)
        {
            var response = await _carService.DeleteCar(id);

            if (response.StatusCode == Domain.Enum.StatusCode.OK)
            {
                return RedirectToAction("GetCars");
            }

            return RedirectToAction("Error");
        }

        [HttpGet]
        public async Task<IActionResult> Save(int id)
        {
            if (id == 0)
            {
                return View();
            }

            var response = await _carService.GetCar(id);

            if (response.StatusCode == Domain.Enum.StatusCode.OK)
            {
                return View(response.Data);
            }

            return RedirectToAction("Error");
        }

        [HttpPost]
        public async Task<IActionResult> Save(CarViewModel carViewModel)
        {
            if (ModelState.IsValid)
            {
                if (carViewModel.CarId == 0)
                {
                    await _carService.CreateCar(carViewModel);
                }
                else
                {
                    await _carService.Edit(carViewModel.CarId, carViewModel);
                }
            }

            return RedirectToAction("GetCars");
        }
    }
}
