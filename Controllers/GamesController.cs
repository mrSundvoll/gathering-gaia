using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using gathering_gaia.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace gathering_gaia.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GamesController : ControllerBase
    {
        // GET: api/<GamesController>
        [HttpGet]
        public IEnumerable<Game> Get()
        {
            return new Game[] { new Game()  };
        }

        // GET api/<GamesController>/5
        [HttpGet("{id}")]
        public Game Get(string guid)
        {
            return new Game();
        }

        // POST api/<GamesController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<GamesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<GamesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
