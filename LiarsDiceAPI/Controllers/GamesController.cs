using System;
using System.Collections.Generic;
using System.IO;
using LiarsDiceAPI.Models;
using LiarsDiceAPI.Models.Exceptions;
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
        [Produces(typeof(IEnumerable<Game>))]
        public ActionResult<IEnumerable<Game>> Get()
        {
            return new Game[] { new Game()  };
        }

        // GET api/<GamesController>/5
        [HttpGet("{id}")]
        [Produces(typeof(Game))]
        public ActionResult<Game> Get(Guid id)
        {
            var game = _cache.Get<Game>(id);
            if (game == null)
                throw new GameException("Game not found.");
            return game;
        }

        // POST api/<GamesController>
        [HttpPost]
        [Produces(typeof(Game))]
        public ActionResult<Game> Post()
        {
            var game = new Game();
            _cache.Set(game.Id, game);
            return game;
        }

        // PUT api/<GamesController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] string value)
        {
            return Ok();
        }

        // DELETE api/<GamesController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            return Ok();
        }
    }
}
