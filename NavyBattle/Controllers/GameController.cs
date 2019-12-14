using Microsoft.AspNetCore.Mvc;
using NavyBattleModels.Interfaces;
using NavyBattleModels.Services;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace NavyBattle.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GameController : Controller
    {
        private IGameService _gameService;

        public GameController(IGameService gameService)
        {
            this._gameService = gameService;
        }

        // GET api/values
        [HttpGet]
        public JsonResult Get()
        {           
            return Json(_gameService.GetAll());
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public JsonResult Get(int id)
        {
            return Json(_gameService.GetById(id));
        }

        // POST api/values
        [HttpPost]
        public JsonResult Post([FromBody] int id)
        {
           return Json(_gameService.CreateGame(id));
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public ActionResult Put(IShot shot)
        {
            var result = _gameService.FireShot(shot);
            if (result.IsSuccess)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
