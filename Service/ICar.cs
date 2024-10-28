using System;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using CarRent_Frontend.Model.Output;

namespace CarRent_Frontend.Service
{
    public interface ICar
    {
        Task<ApiCarResponse<IEnumerable<GetCarOutput>>> GetCar(DateTime rental_date, DateTime return_date, int car_year);
        Task<ApiCarResponse<GetCarOutput>> FindCar(DateTime rental_date, DateTime return_date, int car_year);
    }
}
