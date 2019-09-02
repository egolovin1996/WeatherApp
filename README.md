# WeatherApp
Веб приложение на ASP.NET Core и React для просмотра погоды.

## Запуск
Для запуска приложения можно воспользоваться командой:

`dotnet run --project ./WeatherApp.Web/WeatherApp.Web.csproj`

из папки с проектом.

## Осбенности реализации

Приложение поддерживает расширяемость, для этого достаточно реализовать интерфейс IWeatherProvider и изменить его реализацию в Startup.

Так как приложения высоконагруженное, для работы с Api Open Weather используется потокобезопасный кэш OpenWeatherCache, который также позволяет избежать ограничения на количество запросов в час.

Кроме того в приложении используется обработка ошибок через ErrorHandlingMiddleware.
