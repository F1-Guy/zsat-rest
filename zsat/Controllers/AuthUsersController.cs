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
        [HttpPost]
        public ActionResult<AuthUser> Post(string userName, string password)
        {
            var user = _manager.SignUp(userName, password);
            return Created($"/api/AppUsers/{user.Id}", user);
        }
    }
}
