using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WeatherAppBackend.Service.Impl;

namespace WeatherAppBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class WeatherController : ControllerBase
    {
        private readonly WeatherService weatherService;

        public WeatherController(WeatherService weatherService)
        {
            this.weatherService = weatherService;
        }

        [HttpPost]
        public ActionResult<string> FetchData([FromQuery] string city, [FromQuery] string forecastType)
        {
            try
            {
                var fetchedData = weatherService.GetWeatherData(city, forecastType);
                return Ok(fetchedData);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public ActionResult<string> Get()
        {
            return Ok("You are authenticated and authorized to access this endpoint!");
        }
    }
}
