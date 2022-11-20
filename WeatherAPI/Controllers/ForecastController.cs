using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestSharp;
using System.ComponentModel.DataAnnotations;
using System.Text.Json;

namespace WeatherAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ForecastController : ControllerBase

    {
        public RestClient client;

        public ForecastController() {
            this.client = new RestClient("https://api.openweathermap.org/data/2.5");
        }

        [HttpGet("{lat}/{lon}")]

        public async Task<OkObjectResult>getForecast(string lat,string lon)
        {
            var request = new RestRequest($"/forecast?lat={lat}&lon={lon}&appid=c7f66bad8b39c533f4b070a1de39fd15&units=metric");
            var response =await this.client.ExecuteGetAsync(request);

            return Ok(JsonSerializer.Deserialize<dynamic>(response.Content));
        }
    }
}
