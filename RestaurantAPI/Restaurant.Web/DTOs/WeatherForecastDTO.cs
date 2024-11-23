namespace RestaurantWeb.DTOs
{
    public record WeatherForecastDTO
    {
        public DateOnly Date { get; init; }
        public string? Summary { get; init; }
        public int TemperatureC { get; init; }
        public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
    }
}
