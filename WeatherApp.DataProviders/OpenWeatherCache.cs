using System;
using System.Collections.Generic;
using System.Linq;

namespace WeatherApp.DataAccess
{
    internal static class OpenWeatherCache
    {
        private static string _lastDateKey = GetDateKey();
            
        private static readonly Dictionary<string, string> CachedValues = new Dictionary<string, string>();

        public static void AddValue(string parameters, string value)
        {
            CachedValues.Add(GetKey(parameters), value);
        }
        
        public static bool TryGetValue(string parameters, out string result)
        {
            ClearCacheHourly();
            var key = GetKey(parameters);
            
            return CachedValues.TryGetValue(key, out result);
        }

        private static void ClearCacheHourly()
        {
            if(_lastDateKey == GetDateKey()) return;

            foreach (var key in  CachedValues.Keys.Where(k => k.Contains(_lastDateKey)))
            {
                CachedValues.Remove(key);
            }

            _lastDateKey = GetDateKey();
        }

        private static string GetKey(string parameters) => $"{GetDateKey()}{parameters}";

        private static string GetDateKey() => $"{DateTime.Now:MM/dd/HH}";
    }
}