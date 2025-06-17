using Microsoft.AspNetCore.Mvc;
using Model;

namespace RunningPaceCalculatorAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet("forecast", Name = "GetWeatherForecast")]
        public IEnumerable<WeatherForecast> Get()
        {
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }

        [HttpGet("pace", Name = "GetPace")]
        public IEnumerable<TimeSpan> GetPace()
        {
            return new List<TimeSpan> { 
                new Pace(new TimeSpan(0, 5, 0), 1, MeasurmentSystem.Metric).ReturnPace(),
                new Pace(new TimeSpan(0, 9, 45), 1, MeasurmentSystem.Impereial).ReturnPace(),
                new Pace(new TimeSpan(0, 22, 34), 5, MeasurmentSystem.Metric).ReturnPace(),
                new Pace(new TimeSpan(1, 20, 12), 10, MeasurmentSystem.Impereial).ReturnPace(),
                new Pace(new TimeSpan(3, 49, 7), 42.2, MeasurmentSystem.Metric).ReturnPace()
            };

            // new Pace(new TimeSpan(0, 5, 0), 1000, MeasurmentSystem.Metric);
        }
    }
}
