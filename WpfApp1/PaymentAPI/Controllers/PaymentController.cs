

using System.Linq;

namespace PaymentAPI.Controllers
{
    using Microsoft.AspNetCore.Http;
    using System.Collections.Generic;
    using PaymentAPI.Models;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;

    //[Route("api/[controller]")]
    [ApiController]
    [Route("[controller]")]
    public class PaymentController : ControllerBase
    {
        private readonly PaymentDetailContext _context;

        public PaymentController(PaymentDetailContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return Ok(await _context.PaymentDetails.ToListAsync());
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PaymentDetail))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetById(int id)
        {
            var product = _context.PaymentDetails.ToList().Find(X => X.PaymentDetailID == id);
            if (product == null)
            {
                return NotFound();
            }

            return Ok(product);
        }

        [HttpPost]
        public async Task<IActionResult> ChangePaymentModel(PaymentDetail pessoa)
        {
            if (ModelState.IsValid)
            {
                await _context.AddAsync(pessoa);
                return CreatedAtAction(nameof(GetById), new { id = pessoa.PaymentDetailID }, pessoa);
                //_context.Add(pessoa);
                //await _context.SaveChangesAsync();
            }
            return BadRequest();
        }

        //[ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PaymentDetail))]
        //[ProducesResponseType(StatusCodes.Status404NotFound)]
        // GET: api/<ValuesController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<ValuesController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<ValuesController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<ValuesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
