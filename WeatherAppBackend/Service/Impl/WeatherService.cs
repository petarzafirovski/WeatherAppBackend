using WeatherAppBackend.Constants;

namespace WeatherAppBackend.Service.Impl
{
    public class WeatherService
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;

        public WeatherService(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _configuration = configuration;
        }

        public string GetWeatherData(string city, string forecastType)
        {
            string url;
            if (forecastType.ToUpper().Equals(ForecastCategoryType.Current.ToString()))
                url = GetCurrentWeatherUrl(city);
            else
                url = GetUrlForOtherIntervals(forecastType, city);
            return GetApiResult(url).Result;
        }

        private string GetUrlForOtherIntervals(string forecastType, string city)
        {
            string finalConstructedUrl = forecastType switch
            {
                var str when str.Equals(ForecastCategoryType.TwoDay.GetType(), StringComparison.OrdinalIgnoreCase) => ConstructUrlForMultipleDayForecast(city, ForecastCategoryType.TwoDay.GetInterval()),
                var str when str.Equals(ForecastCategoryType.SevenDay.GetType(), StringComparison.OrdinalIgnoreCase) => ConstructUrlForMultipleDayForecast(city, ForecastCategoryType.SevenDay.GetInterval()),
                var str when str.Equals(ForecastCategoryType.OneHour.GetType(), StringComparison.OrdinalIgnoreCase) => ConstructUrlForOneHourForecast(city),
                _ => GetCurrentWeatherUrl(city),
            };
            return finalConstructedUrl;
        }

        private string ConstructUrlForMultipleDayForecast(string city, string interval)
        {
            string getBaseUrlForDays = GetUrlForMultipleDaysForecast();
            return string.Format(getBaseUrlForDays, city, interval, GetSecretKey());
        }

        private string ConstructUrlForOneHourForecast(string city)
        {
            string getBaseUrlForHourForecast = GetUrlForOneHourForecast();
            return string.Format(getBaseUrlForHourForecast, city, GetSecretKey());
        }

        private async Task<string> GetApiResult(string url)
        {
            var data = await _httpClient.GetAsync(url);
            data.EnsureSuccessStatusCode();
            var json = await data.Content.ReadAsStringAsync();
            return json;
        }

        private string GetUrlForMultipleDaysForecast()
        {
            return _configuration.GetValue<string>("OpenWeatherApi:ForecastForDays");
        }

        private string GetUrlForOneHourForecast()
        {
            return _configuration.GetValue<string>("OpenWeatherApi:HourlyForecast");
        }

        private string GetSecretKey()
        {
            return _configuration.GetValue<string>("OpenWeatherApi:Key");
        }

        private string GetCurrentWeatherUrl(string city)
        {
            var currentWeatherUrl = _configuration.GetValue<string>("OpenWeatherApi:CurrentWeatherUrl");
            return string.Format(currentWeatherUrl, city, GetSecretKey());
        }
    }
}
