using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using StockV1.Hub;

namespace StockV1.Controllers
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

        public WeatherForecastController(IHubContext<MessageHub, IMessageHubClient> _messageHub)
        {
            messageHub = _messageHub;
        }
        private IHubContext<MessageHub, IMessageHubClient> messageHub;

        [HttpPost(Name = "GetWeatherForecast")]
        public string Get()
        {
            var temp= Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
           .ToArray();
           // messageHub.Clients.All.SendStocksToUser(Summaries.ToList());
            return "test";
           
        }
    }
}