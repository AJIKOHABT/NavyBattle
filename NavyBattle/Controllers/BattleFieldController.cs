using System.Collections.Generic;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NavyBattleController.Resource;
using NavyBattleModels;
using NavyBattleModels.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace NavyBattleController.Controllers
{
    
    [Route("api/[controller]")]
    ///Controller for battlefiled validator
    public class BattleFieldController : Controller
    {

        #region properties and fields

        /// <summary>
        /// Service to work with battlefield objects
        /// </summary>
        private readonly IBattleFieldService _battleFieldService;

        /// <summary>
        /// Automapper object
        /// </summary>
        private readonly IMapper _mapper;

        #endregion

        #region constructor

        /// <summary>
        /// User controller constructor
        /// </summary>
        /// <param name="battleFieldService">Service to work with battlefield objects</param>
        /// <param name="mapper">Automapper object</param>
        public BattleFieldController(IBattleFieldService battleFieldService, IMapper mapper)
        {
            this._mapper = mapper;
            this._battleFieldService = battleFieldService;
        }

        #endregion

        #region Api methods

        /// <summary>
        /// Get all battlefields
        /// </summary>
        /// <returns>List of battlefields</returns>
        [HttpGet("all")]
        public ActionResult<IEnumerable<BattleFieldResource>> GetBattleFields()
        {
            var battleFields = _battleFieldService.GetAll();
            var battleFieldResources = _mapper.Map<IEnumerable<BaseBattleField>, IEnumerable<BattleFieldResource>>(battleFields);
            return Ok(battleFieldResources);
        }

        /// <summary>
        /// Get battlefield by id
        /// </summary>
        /// <param name="id">Id of the battlefield</param>
        /// <returns>Battlefield object</returns>
        [HttpGet("get/{id:int}")]
        public ActionResult<BattleFieldResource> GetBattleField(int id)
        {
            var battleField = _battleFieldService.GetById(id);
            var battleFieldResource = _mapper.Map<BaseBattleField, BattleFieldResource>(battleField);
            return Ok(battleFieldResource);
        }

        /// <summary>
        /// Add battlefield
        /// </summary>
        /// <param name="userId">Id of the user</param>
        /// <param name="battleShipResources">List of battleships</param>
        /// <returns></returns>
        [HttpPost("add")]
        public ActionResult CreateBattleField([FromHeader] int userId, [FromBody]IEnumerable<SaveBattleShipResource> battleShipResources)
        {
            var battleShips = _mapper.Map<IEnumerable<SaveBattleShipResource>, IEnumerable<BattleShip>>(battleShipResources);
            var result = _battleFieldService.CreateBattleField(userId, battleShips);
            if (result.IsSuccess)
            {
                return Ok(result.BattleFieldId);
            }
            return BadRequest(result.ErrorList);
        }

        [HttpDelete("delete/{id}")]
        public ActionResult Delete(int id)
        {
            if (id == 0)
                return BadRequest();

            _battleFieldService.Delete(id);

            return NoContent();
        }

        #endregion
    }
}
