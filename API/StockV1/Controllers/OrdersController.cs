using Microsoft.AspNetCore.Mvc;
using StockV1.Context;
using StockV1.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace StockV1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private StockContext _stockContext;
        public OrdersController(StockContext stockContext)
        {
            _stockContext = stockContext;
        }
        // GET: api/<People>
        [HttpGet]
        public IEnumerable<Order> Get()
        {
            return _stockContext.Orders;
        }

        // GET api/<People>/5
        [HttpGet("{id}")]
        public Order Get(int id)
        {
            return _stockContext.Orders.FirstOrDefault(p => p.Id == id);
        }

        // POST api/<People>
        [HttpPost]
        public void Post([FromBody] Order value)
        {

            _stockContext.Orders.Add(value);
            _stockContext.SaveChanges();
        }

        // PUT api/<People>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Order value)
        {
            var Order = _stockContext.Orders.FirstOrDefault(s => s.Id == id);
            if (Order != null)
            {
                _stockContext.Entry<Order>(Order).CurrentValues.SetValues(value);
                _stockContext.SaveChanges();
            }
        }

        // DELETE api/<People>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var Order = _stockContext.Orders.FirstOrDefault(s => s.Id == id);
            if (Order != null)
            {
                _stockContext.Orders.Remove(Order);
                _stockContext.SaveChanges();
            }
        }
    }
}
