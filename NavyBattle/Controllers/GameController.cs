using Microsoft.AspNetCore.Mvc;
using NavyBattleModels.Interfaces;
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
        [HttpGet]
        public JsonResult Get()
        {           
            return Json(_gameService.GetAll());
        }

        [HttpGet("{battleFieldId}")]
        public JsonResult Get(int battleFieldId)
        {
            return Json(_gameService.WaitingForPlayer(battleFieldId));
        }

        [HttpGet]
        public JsonResult Get([FromQuery]int userId, [FromQuery]int gameId)
        {
            return Json(_gameService.CheckForUsersTurn(userId, gameId));
        }

        // POST api/values
        [HttpPost]
        public JsonResult Post([FromBody] int userId, [FromBody] int battleFieldId)
        {
           return Json(_gameService.CreateGameBattleField(userId, battleFieldId));
        }

        // PUT api/values/5
        [HttpPut("{shot}")]
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
