using Microsoft.AspNetCore.Mvc;
using StockV1.Context;
using StockV1.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace StockV1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrokersController : ControllerBase
    {
        private StockContext _stockContext;
        public BrokersController(StockContext stockContext)
        {
            _stockContext = stockContext;
        }
        // GET: api/<People>
        [HttpGet]
        public IEnumerable<Broker> Get()
        {
            return _stockContext.Brokers;
        }

        // GET api/<People>/5
        [HttpGet("{id}")]
        public Broker Get(int id)
        {
            return _stockContext.Brokers.FirstOrDefault(p => p.Id == id);
        }

        // POST api/<People>
        [HttpPost]
        public void Post([FromBody] Broker value)
        {

            _stockContext.Brokers.Add(value);
            _stockContext.SaveChanges();
        }

        // PUT api/<People>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Broker value)
        {
            var Broker = _stockContext.Brokers.FirstOrDefault(s => s.Id == id);
            if (Broker != null)
            {
                _stockContext.Entry<Broker>(Broker).CurrentValues.SetValues(value);
                _stockContext.SaveChanges();
            }
        }

        // DELETE api/<People>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var Broker = _stockContext.Brokers.FirstOrDefault(s => s.Id == id);
            if (Broker != null)
            {
                _stockContext.Brokers.Remove(Broker);
                _stockContext.SaveChanges();
            }
        }
    }
}
