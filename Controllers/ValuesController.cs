using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using StockApp1.API.MyData;

namespace StockApp1.API.Controllers
{
    [Route("api/[controller]")]
 
    public class ValuesController : ControllerBase
    {
        private readonly StockDataContext _context;
        public ValuesController(StockApp1.API.MyData.StockDataContext context) => _context = context;


        // GET api/values
        [HttpGet]
        public IActionResult GetValues()
        {
            var values = _context.Values.ToList();

            return Ok(values);  //
        }

        // GET api/values/5
        // if id not found, returns a '204 no content' which is fine for now
        [HttpGet("{id}")]
        public IActionResult GetValue(int id)
        {
            var value = _context.Values.FirstOrDefault(x => x.Id == id);

            return Ok(value);
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
