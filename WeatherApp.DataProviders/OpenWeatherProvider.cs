using System;
using System.Net.Http;
using System.Threading.Tasks;
using WeatherApp.DataAccess.Interfaces;

namespace WeatherApp.DataAccess
{
    public class OpenWeatherProvider: IWeatherProvider
    {
        private const string AppId = "&appid=9daaa9b770dea5a24cc4d34347dc924c";
        private const string BaseApiUrl = "https://api.openweathermap.org/data/2.5/weather?";
        
        private readonly HttpClient _client = new HttpClient();
        
        public async Task<string> GetWeatherByCityName(string cityName)
        {
            return await GetWeatherBase($"q={cityName}");
        }

        public async Task<string> GetWeatherByCityId(int cityId)
        {
            return await GetWeatherBase($"id={cityId}");
        }

        public async Task<string> GetWeatherByCoords(double latitude, double longitude)
        {
            return await GetWeatherBase($"lat={latitude}&lon={longitude}");
        }

        private async Task<string> GetWeatherBase(string parameters)
        {
            if (OpenWeatherCache.TryGetValue(parameters, out var result))
            {
                return result;
            }
            
            var response = await _client.GetAsync(GetRequestString(parameters));
            ValidateResponse(response);
            
            return await response.Content.ReadAsStringAsync();
        }

        private static string GetRequestString(string parameters) => $"{BaseApiUrl}{parameters}{AppId}";

        private static void ValidateResponse(HttpResponseMessage response)
        {
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception();
            }
        }
    }
}