using LocalWise.Interfaces;
using LocalWise.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace APILocalWise.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly IAccountRepository _accountRepository;

        public ValuesController([FromServices] IAccountRepository  accountRepository)
        {
            _accountRepository = accountRepository;
        }

        // GET: api/<ValuesController>
        [HttpGet]
        public async Task<IEnumerable<Pessoa>> Get()
        {
            return await _accountRepository.API_GetAll();

        }

        // GET api/<ValuesController>/5
        [HttpGet("{id}")]
        public async Task<Pessoa> Get(string id)
        {
            return await _accountRepository.GetByIdAsync(id);
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
