using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NavyBattleController.Resource;
using NavyBattleModels.Models;
using NavyBattleModels.Services;
using System.Collections.Generic;

namespace NavyBattleController.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : Controller    
    {

        #region properties and fields

        /// <summary>
        /// Service to work with user objects
        /// </summary>
        private readonly IUserService _userService;

        /// <summary>
        /// Automapper object
        /// </summary>
        private readonly IMapper _mapper;

        #endregion

        #region constructor

        /// <summary>
        /// User controller constructor
        /// </summary>
        /// <param name="userService">Service to work with user objects</param>
        /// <param name="mapper">Automapper object</param>
        public UsersController(IUserService userService, IMapper mapper)
        {
            this._mapper = mapper;
            this._userService = userService;
        }

        #endregion

        #region Api methods

        /// <summary>
        /// Add user by post
        /// </summary>
        /// <param name="saveUser">User object</param>
        /// <returns>Id of the added user</returns>
        [HttpPost("add")]
        public ActionResult Post([FromBody] SaveUserResource saveUser)
        {
            if (saveUser == null)
            {
                return BadRequest();
            }

            var user = _mapper.Map<SaveUserResource, User>(saveUser);
            var result = _userService.AddUser(user);
            return Ok(result);
        }

        /// <summary>
        /// Get User by Id
        /// </summary>
        /// <param name="userId">Id of the user</param>
        /// <returns>User object</returns>
        [HttpGet("{userId:int}")]
        public ActionResult<UserResource> GetUser(int userId)
        {
            var user = _userService.GetById(userId);
            var userResource = _mapper.Map<User, UserResource>(user);
            return Ok(userResource);
        }

        /// <summary>
        /// Get all users registered in the system
        /// </summary>
        /// <returns>List of users</returns>
        [HttpGet("all")]
        public ActionResult<IEnumerable<UserResource>> GetAll()
        {
            var users = _userService.GetAll();
            var userResources = _mapper.Map<IEnumerable<User>, IEnumerable<UserResource>>(users);
            return Ok(userResources);
        }

        #endregion

    }
}