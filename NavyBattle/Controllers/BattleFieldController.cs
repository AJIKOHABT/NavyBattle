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
        [HttpGet]
        public JsonResult GetBattleFields()
        {
            return Json(_battleFieldService.GetAll());
        }

        // GET api/<controller>/5
        [HttpGet("{id:int}")]
        public JsonResult GetBattleField(int id)
        {
            return Json(_battleFieldService.GetById(id));
        }

        // POST api/<controller>
        [HttpPost]
        public ActionResult CreateBattleField([FromHeader] int userId, [FromBody]List<BattleShip> battleShips)
        {
            var result = _battleFieldService.CreateBattleField(userId, battleShips);
            if (result.IsSuccess)
            {
                return Ok(result.BattleFieldId);
            }
            return BadRequest(result.ErrorList);
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
