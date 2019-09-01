using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WeatherApp.DataAccess.Interfaces;

namespace WeatherApp.Web.Controllers
{
    [Route("api/weather")]
    public class WeatherController : Controller
    {
        private readonly IWeatherProvider _weatherProvider;
        
        public WeatherController(IWeatherProvider weatherProvider)
        {
            _weatherProvider = weatherProvider;
        }

        [HttpGet("getWeatherByCityName/{cityName}")]
        public async Task<string> GetWeatherByCityName(string cityName)
        {
            return await _weatherProvider.GetWeatherByCityName(cityName, 8);
        }
        
        [HttpGet("getWeatherByCoords/{latitude}/{longitude}")]
        public async Task<string> GetWeatherByCoords(double latitude, double longitude)
        {
            return await _weatherProvider.GetWeatherByCoords(latitude, longitude, 8);
        }
    }
}