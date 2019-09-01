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

        [HttpGet("getWeatherByCityName/{cityName}/{daysCount}")]
        public async Task<string> GetWeatherByCityName(string cityName, int daysCount)
        {
            return await _weatherProvider.GetWeatherByCityName(cityName, daysCount);
        }
        
        [HttpGet("getWeatherByCoords/{latitude}/{longitude}/{daysCount}")]
        public async Task<string> GetWeatherByCoords(double latitude, double longitude, int daysCount)
        {
            return await _weatherProvider.GetWeatherByCoords(latitude, longitude, daysCount);
        }
    }
}