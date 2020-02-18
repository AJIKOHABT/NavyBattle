using Microsoft.AspNetCore.Mvc;
using NavyBattleModels.Interfaces;
using NavyBattleModels.Models;
using NavyBattleModels.Services;

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
        [HttpGet("all")]
        public JsonResult Get()
        {           
            return Json(_gameService.GetAll());
        }

        [HttpGet("checkready/{battleFieldId:int}")]
        public JsonResult Get(int battleFieldId)
        {
            return Json(_gameService.WaitingForPlayer(battleFieldId));
        }

        [HttpGet("checkturn")]
        public JsonResult Get([FromQuery]int userId, [FromQuery]int gameId)
        {
            return Json(_gameService.CheckForUsersTurn(userId, gameId));
        }

        // POST api/values
        [HttpPost("creategame")]
        public JsonResult Post([FromHeader] int userId, [FromBody] int battleFieldId)
        {
           return Json(_gameService.CreateGameBattleField(userId, battleFieldId));
        }

        // PUT api/values/5
        [HttpPut("fire/{shot}")]
        public ActionResult Put(Shot shot)
        {
            var result = _gameService.FireShot(shot);
            if (result.IsSuccess)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }        
    }
}
