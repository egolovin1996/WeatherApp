using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WeatherApp.DataAccess.Interfaces;

namespace WeatherApp.Web.Controllers
{
    public class WeatherController : Controller
    {
        private readonly IWeatherProvider _weatherProvider;
        
        public WeatherController(IWeatherProvider weatherProvider)
        {
            _weatherProvider = weatherProvider;
        }

        [HttpGet]
        public async Task<string> GetWeatherByCityName(string cityName)
        {
            return await _weatherProvider.GetWeatherByCityName(cityName);
        }
        
        [HttpGet]
        public async Task<string> GetWeatherByCityId(int cityId)
        {
            return await _weatherProvider.GetWeatherByCityId(cityId);
        }
        
        [HttpGet]
        public async Task<string> GetWeatherByCoords(double latitude, double longitude)
        {
            return await _weatherProvider.GetWeatherByCoords(latitude, longitude);
        }
    }
}