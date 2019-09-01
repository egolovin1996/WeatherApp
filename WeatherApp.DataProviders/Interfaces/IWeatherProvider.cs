using System.Threading.Tasks;

namespace WeatherApp.DataAccess.Interfaces
{
    public interface IWeatherProvider
    {
        Task<string> GetWeatherByCityName(string cityName);

        Task<string> GetWeatherByCityId(int cityId);

        Task<string> GetWeatherByCoords(double latitude, double longitude);
        
        
    }
}