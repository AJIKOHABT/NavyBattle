using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NavyBattleController.Resource;
using NavyBattleModels.Interfaces;
using NavyBattleModels.Models;
using NavyBattleModels.Services;
using NavyBattleModels.Validators;
using System.Collections.Generic;

namespace NavyBattle.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GameController : Controller
    {


        #region properties and fields

        /// <summary>
        /// Service to work with game objects
        /// </summary>
        private readonly IGameService _gameService;

        /// <summary>
        /// Automapper object
        /// </summary>
        private readonly IMapper _mapper;

        #endregion

        #region constructor

        /// <summary>
        /// User controller constructor
        /// </summary>
        /// <param name="gameService">Service to work with game objects</param>
        /// <param name="mapper">Automapper object</param>
        public GameController(IGameService gameService, IMapper mapper)
        {
            this._mapper = mapper;
            this._gameService = gameService;
        }

        #endregion

        #region Api methods

        /// <summary>
        /// Get all games
        /// </summary>
        /// <returns>List of the games</returns>
        [HttpGet("all")]
        public ActionResult<IEnumerable<GameResource>> Get()
        {
            var games = _gameService.GetAll();
            var gameResources = _mapper.Map<IEnumerable<Game>, IEnumerable<GameResource>>(games);
            return Ok(gameResources);
        }

        /// <summary>
        /// Check any other player to start the game
        /// </summary>
        /// <param name="battleFieldId">Id of the battlefield with which to start the game</param>
        /// <returns></returns>
        [HttpGet("checkready/{battleFieldId:int}")]
        public ActionResult<BattleFieldResult> Get(int battleFieldId)
        {
            return Ok(_gameService.WaitingForPlayer(battleFieldId));
        }

        /// <summary>
        /// Check whos turn now
        /// </summary>
        /// <param name="userId">Id of the user</param>
        /// <param name="gameId">Id of the game</param>
        /// <returns></returns>
        [HttpGet("checkturn")]
        public ActionResult<GameResult> Get([FromQuery]int userId, [FromQuery]int gameId)
        {
            return Ok(_gameService.CheckForUsersTurn(userId, gameId));
        }

        /// <summary>
        /// Create gamebattlefield to start searching the game
        /// </summary>
        /// <param name="userId">Id of the user</param>
        /// <param name="battleFieldId">Id of the battlefield</param>
        /// <returns></returns>
        [HttpPost("creategame")]
        public ActionResult<BattleFieldResult> Post([FromHeader] int userId, [FromBody] int battleFieldId)
        {
           return Json(_gameService.CreateGameBattleField(userId, battleFieldId));
        }

        
        /// <summary>
        /// Fire a shot to the enemy battlefield
        /// </summary>
        /// <param name="shotResource">Shot object</param>
        /// <returns></returns>
        [HttpPut("fire/{shot}")]
        public ActionResult<ShotResult> Put(SaveShotResource saveShot)
        {
            var shot = _mapper.Map<SaveShotResource, Shot>(saveShot);
            var result = _gameService.FireShot(shot);
            if (result.IsSuccess)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        #endregion
    }
}
