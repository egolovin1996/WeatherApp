using System;
using System.Net.Http;
using System.Threading.Tasks;
using WeatherApp.DataAccess.Interfaces;

namespace WeatherApp.DataAccess
{
    public class OpenWeatherProvider: IWeatherProvider
    {
        private const string AppId = "&appid=9daaa9b770dea5a24cc4d34347dc924c";
        private const string BaseApiUrl = "https://api.openweathermap.org/data/2.5/forecast?";
        
        private readonly HttpClient _client = new HttpClient();
        
        public async Task<string> GetWeatherByCityName(string cityName, int daysCount)
        {
            return await GetWeatherBase($"q={cityName}", daysCount);
        }

        public async Task<string> GetWeatherByCoords(double latitude, double longitude, int daysCount)
        {
            return await GetWeatherBase($"lat={latitude}&lon={longitude}", daysCount);
        }

        private async Task<string> GetWeatherBase(string parameters, int daysCount)
        {
            var parametersWithCount = $"{parameters}&cnt={daysCount}";
            if (OpenWeatherCache.TryGetValue(parametersWithCount, out var cachedResult))
            {
                return cachedResult;
            }
            
            var response = await _client.GetAsync(GetRequestString(parametersWithCount));
            ValidateResponse(response);

            var result = await response.Content.ReadAsStringAsync();
            OpenWeatherCache.AddValue(parametersWithCount, result);

            return result;
        }

        private static string GetRequestString(string parameters) =>
            $"{BaseApiUrl}{parameters}&units=metric{AppId}";

        private static void ValidateResponse(HttpResponseMessage response)
        {
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception();
            }
        }
    }
}