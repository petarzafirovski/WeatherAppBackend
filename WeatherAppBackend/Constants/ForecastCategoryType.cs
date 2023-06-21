namespace WeatherAppBackend.Constants
{
    public class ForecastCategoryType
    {
        public string? Type { get; private set; }
        public string? Interval { get; set; }
        public ForecastCategoryType(string Type, string Interval)
        {
            this.Type = Type;
            this.Interval = Interval;
        }

        public ForecastCategoryType(string Type)
        {
            this.Type = Type;
        }

        public string GetType()
        {
            return Type;
        }

        public string GetInterval()
        {
            return Interval;
        }

        public static ForecastCategoryType Current { get { return new ForecastCategoryType("CURRENT"); } }
        public static ForecastCategoryType OneHour { get { return new ForecastCategoryType("ONEHOUR", "1"); } }
        public static ForecastCategoryType TwoDay { get { return new ForecastCategoryType("TWODAY", "2"); } }
        public static ForecastCategoryType SevenDay { get { return new ForecastCategoryType("SEVENDAY", "7"); } }
    }
}
