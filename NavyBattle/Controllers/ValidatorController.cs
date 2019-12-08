using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NavyBattleModels;
using NavyBattleModels.Validators.Interfaces;
using NavyBattleModels.Interfaces;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace NavyBattleController.Controllers
{
    
    [Route("api/[controller]")]
    ///Controller for battlefiled validator
    public class ValidatorController : Controller
    {
        // GET: api/<controller>
        [HttpGet]
        public JsonResult Get([FromServices] IBattleField battleField)
        {
            return Json(battleField.GetAll);
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public JsonResult Get(int id, [FromServices] IBattleField battleField)
        {
            return Json(battleField.GetById(id));
        }

        // POST api/<controller>
        [HttpPost]
        public IActionResult Post([FromBody]List<BattleShip> battleShips, [FromServices] IBattleFieldValidator validator)
        {
            var result = validator.Validate(battleShips);
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
