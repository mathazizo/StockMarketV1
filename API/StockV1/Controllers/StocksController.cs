using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using StockV1.Context;
using StockV1.Hub;
using StockV1.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace StockV1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StocksController : ControllerBase
    {
        private StockContext _stockContext;
        private IHubContext<MessageHub, IMessageHubClient> messageHub;
        public StocksController(StockContext stockContext, IHubContext<MessageHub, IMessageHubClient> _messageHub)
        {
            _stockContext = stockContext;
            messageHub = _messageHub;
        }
       
        // GET: api/<People>
        [HttpGet]
        public IEnumerable<Stock> Get()
        {
            return _stockContext.Stocks;
        }

        // GET api/<People>/5
        [HttpGet("{id}")]
        public Stock Get(int id)
        {
            return _stockContext.Stocks.FirstOrDefault(p => p.Id == id);
        }

        // POST api/<People>
        [HttpPost]
        public void Post([FromBody] Stock value)
        {

            _stockContext.Stocks.Add(value);
            _stockContext.SaveChanges();
            messageHub.Clients.All.SendStocksToUser(value);
        }

        // PUT api/<People>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Stock value)
        {
            var Stock = _stockContext.Stocks.FirstOrDefault(s => s.Id == id);
            if (Stock != null)
            {
                _stockContext.Entry<Stock>(Stock).CurrentValues.SetValues(value);
                _stockContext.SaveChanges();
            }
        }

        // DELETE api/<People>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var Stock = _stockContext.Stocks.FirstOrDefault(s => s.Id == id);
            if (Stock != null)
            {
                _stockContext.Stocks.Remove(Stock);
                _stockContext.SaveChanges();
            }
        }
    }
}
