using System.Threading.Tasks;

namespace WeatherApp.DataAccess.Interfaces
{
    public interface IWeatherProvider
    {
        Task<string> GetWeatherByCityName(string cityName, int daysCount);

        Task<string> GetWeatherByCoords(double latitude, double longitude, int daysCount);
    }
}