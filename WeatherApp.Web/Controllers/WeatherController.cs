using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WeatherApp.DataAccess.Interfaces;

namespace WeatherApp.Web.Controllers
{
    /// <summary>
    /// Controller for receiving weather data
    /// </summary>
    [Route("api/weather")]
    public class WeatherController : Controller
    {
        private readonly IWeatherProvider _weatherProvider;
        
        public WeatherController(IWeatherProvider weatherProvider)
        {
            _weatherProvider = weatherProvider;
        }

        /// <summary>
        /// Get weather by city name for a days count
        /// </summary>
        /// <param name="cityName">City name</param>
        /// <param name="daysCount">The number of days to get the weather</param>
        /// <returns>Weather in json format</returns>
        [HttpGet("getWeatherByCityName/{cityName}/{daysCount}")]
        public async Task<string> GetWeatherByCityName(string cityName, int daysCount)
        {
            return await _weatherProvider.GetWeatherByCityName(cityName, daysCount);
        }

        /// <summary>
        /// Get weather by coordinates for a days count
        /// </summary>
        /// <param name="latitude">Latitude</param>
        /// <param name="longitude">Longitude</param>
        /// <param name="daysCount">The number of days for getting the weather</param>
        /// <returns>Weather in json format</returns>
        [HttpGet("getWeatherByCoords/{latitude}/{longitude}/{daysCount}")]
        public async Task<string> GetWeatherByCoords(double latitude, double longitude, int daysCount)
        {
            return await _weatherProvider.GetWeatherByCoords(latitude, longitude, daysCount);
        }
    }
}