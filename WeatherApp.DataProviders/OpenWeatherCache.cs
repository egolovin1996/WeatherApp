using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;

namespace WeatherApp.DataAccess
{
    internal static class OpenWeatherCache
    {
        private static volatile string _lastDateKey = GetDateKey();
            
        private static readonly ConcurrentDictionary<string, string> CachedValues = new ConcurrentDictionary<string, string>();

        public static void AddValue(string parameters, string value)
        {
            CachedValues.TryAdd(GetKey(parameters), value);
        }
        
        public static bool TryGetValue(string parameters, out string result)
        {
            ClearCacheHourly();
            var key = GetKey(parameters);
            
            return CachedValues.TryGetValue(key, out result);
        }

        private static void ClearCacheHourly()
        {
            var newKey = GetDateKey();
            var previousKey = Interlocked.CompareExchange(ref _lastDateKey, newKey, GetDateKeyHourBefore());
            if (previousKey.Equals(newKey)) return;

            foreach (var key in  CachedValues.Keys.Where(k => k.Contains(previousKey)))
            {
                CachedValues.TryRemove(key, out _);
            }
        }

        private static string GetKey(string parameters) => $"{GetDateKey()}{parameters}";

        private static string GetDateKey() => string.Intern($"{DateTime.Now:MM/dd/HH}");

        private static string GetDateKeyHourBefore() => string.Intern($"{DateTime.Now.AddHours(-1):MM/dd/HH}");
    }
}