using DemoMvcApplication.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoMvcApplication.Controllers
{
    [Route("api/{controller}")]
    public class WeatherForecastsController : Controller
    {
        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            return new List<WeatherForecast>
            {
                new WeatherForecast
                {
                    Id = 1,
                    Date = DateTime.Today,
                    Summary = "Sunny",
                    TemperatureC = 15
                },
                new WeatherForecast
                {
                    Id=2,
                    Date = DateTime.Today.AddDays(1),
                    Summary = "Cloudy",
                    TemperatureC = 12
                }
            };
        }

        [HttpGet("{id}")]
        public WeatherForecast GetΒyId(int id)
        {
            return new WeatherForecast
            {
                Id = 1,
                Date = DateTime.Today,
                Summary = "Sunny",
                TemperatureC = 15
            };
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteById(int id)
        {
            //fake delete
            return Ok();
        }
    }
}
