using System.Threading.Tasks;

namespace WeatherApp.DataAccess.Interfaces
{
    /// <summary>
    /// Interface for receiving weather data
    /// </summary>
    public interface IWeatherProvider
    {
        /// <summary>
        /// Get weather by city name for a days count
        /// </summary>
        /// <param name="cityName">City name</param>
        /// <param name="daysCount">The number of days to get the weather</param>
        /// <returns>Weather in json format</returns>
        Task<string> GetWeatherByCityName(string cityName, int daysCount);

        /// <summary>
        /// Get weather by coordinates for a days count
        /// </summary>
        /// <param name="latitude">Latitude</param>
        /// <param name="longitude">Longitude</param>
        /// <param name="daysCount">The number of days for getting the weather</param>
        /// <returns>Weather in json format</returns>
        Task<string> GetWeatherByCoords(double latitude, double longitude, int daysCount);
    }
}