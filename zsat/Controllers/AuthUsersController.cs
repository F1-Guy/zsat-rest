using Microsoft.AspNetCore.Mvc;
using zsat.Interfaces;
using zsat.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace zsat.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthUsersController : ControllerBase
    {
        private readonly IAuthUser _manager;

        public AuthUsersController(IAuthUser manager)
        {
            _manager = manager;
        }

        // POST api/<AuthUsersController>
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Route("[action]")]
        [HttpPost]
        public ActionResult<AuthUser> SignUp(string userName, string password, string fullName)
        {
            try
            {
                var user = _manager.SignUp(userName, password, fullName);
                return Created($"/api/AppUsers/{user.Id}", user);
            }
            catch (ArgumentNullException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST api/<AuthUsersController>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Route("[action]")]
        [HttpPost]
        public ActionResult<AuthUser> SignIn(string userName, string password)
        {
            try
            {
                var user = _manager.SignIn(userName, password);
                if (user == null) return BadRequest("No such user found.");
                return Ok(user);
            }
            catch (ArgumentOutOfRangeException ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
