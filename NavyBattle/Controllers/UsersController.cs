using Microsoft.AspNetCore.Mvc;
using NavyBattleModels.Models;
using NavyBattleModels.Services;

namespace NavyBattleController.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : Controller
    {
        private IUserService _userService;

        public UsersController(IUserService userService)
        {
            this._userService = userService;
        }

        // POST api/values
        [HttpPost("add")]
        public ActionResult Post([FromBody] User user)
        {
            if (user == null)
            {
                return BadRequest();
            }
            var result = _userService.AddUser(user);
            return Ok(result);
        }

        [HttpGet("{userId:int}")]
        public JsonResult GetUser(int userId)
        {
            return Json(_userService.GetById(userId));
        }

        [HttpGet("all")]
        public JsonResult GetAll()
        {
            return Json(_userService.GetAll());
        }
    }
}