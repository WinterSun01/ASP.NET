public class WeatherForecast
{
    public string City { get; set; }
    public string Description { get; set; }
    public float TemperatureC { get; set; }
    public float TemperatureF => 32 + (TemperatureC / 0.5556f);
    public DateTime Date { get; set; }
}
