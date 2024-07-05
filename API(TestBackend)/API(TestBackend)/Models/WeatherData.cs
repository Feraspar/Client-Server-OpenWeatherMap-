namespace API_TestBackend_.Models
{
    public class WeatherData
    {
        public string City { get; set; }
        public DateTime CityTime { get; set; }
        public DateTime ServerTime { get; set; }
        public TimeSpan TimeDifference { get; set; }
        public double? TemperatureC { get; set; }   
        public double? Pressure { get; set; }
        public int? Humidity { get; set; }
        public double? WindSpeed { get; set;}
        public int? Cloudy { get; set; }
    }
}
