using Microsoft.AspNetCore.Mvc;
using StockV1.Context;
using StockV1.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace StockV1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private StockContext _stockContext;
        public PersonController(StockContext stockContext)
        {
            _stockContext = stockContext;
        }
        // GET: api/<People>
        [HttpGet]
        public IEnumerable<Person> Get()
        {
            return _stockContext.Persons;
        }

        // GET api/<People>/5
        [HttpGet("{id}")]
        public Person Get(int id)
        {
            return _stockContext.Persons.FirstOrDefault(p => p.Id == id);
        }

        // POST api/<People>
        [HttpPost]
        public void Post([FromBody] Person value)
        {

            _stockContext.Persons.Add(value);
            _stockContext.SaveChanges();
        }

        // PUT api/<People>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Person value)
        {
            var person = _stockContext.Persons.FirstOrDefault(s => s.Id == id);
            if (person != null)
            {
                _stockContext.Entry<Person>(person).CurrentValues.SetValues(value);
                _stockContext.SaveChanges();
            }
        }

        // DELETE api/<People>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var person = _stockContext.Persons.FirstOrDefault(s => s.Id == id);
            if (person != null)
            {
                _stockContext.Persons.Remove(person);
                _stockContext.SaveChanges();
            }
        }
    }
}
