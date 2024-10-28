using Microsoft.AspNetCore.Mvc;
using CarRent_Frontend.Service;
using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CarRent_Frontend.Controller
{
    public class CarController
    {
        private readonly ICar _carApi;

        public CarController(ICar carApi)
        {
            _carApi = carApi;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> GetCar(DateTime rental_date, DateTime return_date, int car_year)
        {
            var result = await _carApi.GetCar(rental_date, return_date, car_year);
            return Json(result);
        }

        public async Task<IActionResult> FindCar(DateTime rental_date, DateTime return_date, int car_year)
        {
            var result = await _carApi.FindCar(rental_date, return_date, car_year);
            return Json(result);
        }
    }
}
