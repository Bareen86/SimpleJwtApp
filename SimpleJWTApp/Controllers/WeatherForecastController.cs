using Microsoft.AspNetCore.Mvc;
using SimpleJWTApp.Api.Attributes;

namespace SimpleJWTApp.Controllers
{
    [ApiController]
    [Route( "[controller]" )]
    [Jwt]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController( ILogger<WeatherForecastController> logger )
        {
            _logger = logger;
        }

        [Jwt]
        [HttpGet( "GetWeatherForecast" )]
        public IActionResult GetForecast()
        {
            return Ok( Summaries );
;       }
    }
}