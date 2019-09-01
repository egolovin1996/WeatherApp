using System;
using System.Collections.Generic;

namespace WeatherApp.DataAccess
{
    internal static class OpenWeatherCache
    {
        private static readonly Dictionary<string, string> CachedValues = new Dictionary<string, string>();

        public static void AddValue(string parameters, string value)
        {
            CachedValues.Add(GetKey(parameters), value);
        }
        
        public static bool TryGetValue(string parameters, out string result)
        {
            var key = GetKey(parameters);
            if (CachedValues.ContainsKey(key))
            {
                result = CachedValues[key];
                return true;
            }

            result = null;
            return false;
        }

        private static string GetKey(string parameters) => $"{DateTime.Now.ToShortDateString()}{parameters}";
    }
}