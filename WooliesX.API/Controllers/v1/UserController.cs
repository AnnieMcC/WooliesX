using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WooliesX.Core.Models;
using WooliesX.Core.Interfaces;
using AutoMapper;
using WooliesX.API.Resources;
using WooliesX.Core.Resources;
using System.Linq;

namespace WooliesX.API.Controllers.v1
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : Controller
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        // GET: api/values
        [HttpGet(Name = nameof(GetAllUsers))]
        [ProducesResponseType(typeof(IEnumerable<UserResource>), 200)]
        [ProducesResponseType(400)]
        public async Task<ActionResult<IEnumerable<UserResource>>> GetAllUsers()
        {
            var users = await _userService.GetUsers();

            return Ok(users);
        }

        // GET api/values/5
        [HttpGet("{id}", Name = nameof(GetUserById))]
        [ProducesResponseType(typeof(UserResource), 200)]
        [ProducesResponseType(400)]
        public async Task<ActionResult<UserResource>> GetUserById(int id)
        {
            var user = await _userService.GetUserById(id);

            if(user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }
    }
}
