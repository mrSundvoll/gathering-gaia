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

        [HttpPut("{id}/players")]
        public Guid Join(Guid id, [FromBody] string username)
        {
            var game = _cache.Get<Game>(id);
            var player = game.JoinGame(username);
            return player.UserId;
        }

        [HttpPut("{id}/start")]
        public void Start(Guid id, [FromBody] Guid userId)
        {
            
        }

        [HttpPut("{id}/call")]
        public void Call(Guid id, [FromBody] Guid userId)
        {
            
        }

        [HttpPut("{id}/bid")]
        public void Call(Guid id, [FromBody] Bid bid)
        {
            
        }

        // DELETE api/<GamesController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            return Ok();
        }
    }
}
