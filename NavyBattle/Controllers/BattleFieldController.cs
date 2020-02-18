using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using NavyBattleModels;
using NavyBattleModels.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace NavyBattleController.Controllers
{
    
    [Route("api/[controller]")]
    ///Controller for battlefiled validator
    public class BattleFieldController : Controller
    {
        private IBattleFieldService _battleFieldService;

        public BattleFieldController(IBattleFieldService battleFieldService)
        {
            this._battleFieldService = battleFieldService;
        }

        // GET: api/<controller>
        [HttpGet("all")]
        public JsonResult GetBattleFields()
        {
            return Json(_battleFieldService.GetAll());
        }

        // GET api/<controller>/5
        [HttpGet("get/{id:int}")]
        public JsonResult GetBattleField(int id)
        {
            return Json(_battleFieldService.GetById(id));
        }

        // POST api/<controller>
        [HttpPost("add")]
        public ActionResult CreateBattleField([FromHeader] int userId, [FromBody]List<BattleShip> battleShips)
        {
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
    }
}
