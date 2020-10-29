using System;
using System.Collections.Generic;
using LiarsDiceAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LiarsDiceAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GamesController : ControllerBase
    {
        private IMemoryCache _cache;
        public GamesController(IMemoryCache memoryCache)
        {
            _cache = memoryCache;
        }

        // GET: api/<GamesController>
        [HttpGet]
        public IEnumerable<Game> Get()
        {
            return new Game[] { new Game()  };
        }

        // GET api/<GamesController>/5
        [HttpGet("{id}")]
        public Game Get(Guid id)
        {
            var game = _cache.Get<Game>(id);
            return game;
        }

        // POST api/<GamesController>
        [HttpPost]
        public Game Post()
        {
            var game = new Game();
            _cache.Set(game.Id, game);
            return game;
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
