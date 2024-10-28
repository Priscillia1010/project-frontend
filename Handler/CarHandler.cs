using System;
using CarRent_Frontend.Model.Output;
using CarRent_Frontend.Service;
using Newtonsoft.Json;

namespace CarRent_Frontend.Handler
{
    public class CarHandler : ICar
    {
        private readonly IConfiguration _configuration;
        private readonly string baseUrl = "";
        private HttpClient httpClient = new HttpClient();

        public CarHandler(IConfiguration configuration)
        {
            _configuration = configuration;
            baseUrl = _configuration["apiEndpoint"];
        }

        public async Task<ApiCarResponse<IEnumerable<GetCarOutput>>> GetCar(DateTime rental_date, DateTime return_date, int car_year)
        {
            string endpoint = $"{baseUrl}Car?rentalDate={rental_date:yyyy-MM-dd}&returnDate={return_date:yyyy-MM-dd}&year={car_year}";
            var carOutput = new ApiCarResponse<IEnumerable<GetCarOutput>>();

            var response = await httpClient.GetAsync(endpoint);
            string apiResponse = await response.Content.ReadAsStringAsync();

            if(!string.IsNullOrEmpty(apiResponse))
            {
                carOutput = JsonConvert.DeserializeObject<ApiCarResponse<IEnumerable<GetCarOutput>>>(apiResponse);
            }
            return carOutput;
        }

        public async Task<ApiCarResponse<GetCarOutput>> FindCar(string id)
        {
            string endpoint = baseUrl + "Car/" + id;

            var carOutput = new ApiCarResponse<GetCarOutput>();

            var response = await httpClient.GetAsync(endpoint);
            string apiResponse = await response.Content.ReadAsStringAsync();

            if(!string.IsNullOrEmpty(apiResponse))
            {
                carOutput = JsonConvert.DeserializeObject<ApiCarResponse<GetCarOutput>>(apiResponse);
            }
            return carOutput;
        }
    }
}
