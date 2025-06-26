using Microsoft.AspNetCore.Mvc;
using Model;

namespace RunningPaceCalculatorAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RaceResultController : ControllerBase
    {
        [HttpGet("predict")]
        public IActionResult Predict(
            [FromQuery] string time, // format "hh:mm:ss"
            [FromQuery] double distance,
            [FromQuery] MeasurmentSystem measurmentSystem)
        {
            // Only accept strict hh:mm:ss format
            if (!TimeSpan.TryParseExact(time, "hh\\:mm\\:ss", null, out TimeSpan parsedTime))
            {
                return BadRequest("Invalid time format. Use hh:mm:ss.");
            }

            // Distance must be valid
            if (distance <= 0)
            {
                return BadRequest("Distance must be a positive number.");
            }

            // Create Pace and Prediction objects
            var pace = new Pace(parsedTime, distance, measurmentSystem);
            var prediction = new RaceResultPrediction(pace);

            // Return full prediction object including custom distance data
            return Ok(prediction);
        }

        private bool TryParseTime(string input, out TimeSpan timeSpan)
        {
            timeSpan = TimeSpan.Zero;

            if (TimeSpan.TryParse(input, out timeSpan))
                return true;

            // Handle mm:ss format explicitly
            var parts = input.Split(':');
            if (parts.Length == 2 && int.TryParse(parts[0], out int minutes) && int.TryParse(parts[1], out int seconds))
            {
                timeSpan = new TimeSpan(0, minutes, seconds);
                return true;
            }

            return false;
        }
    }
}

