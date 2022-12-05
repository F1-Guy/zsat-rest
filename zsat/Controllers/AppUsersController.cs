using Microsoft.AspNetCore.Mvc;
using zsat.Interfaces;
using zsat.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace zsat.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppUsersController : ControllerBase
    {
        private readonly IAppUser _manager;

        public AppUsersController(IAppUser manager)
        {
            _manager = manager;
        }

        // GET: api/<AppUsersController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<AppUsersController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<AppUsersController>
        [HttpPost]
        public ActionResult<AppUser> Post(string name, string email, string password)
        {
            if (name == null) return BadRequest();
            try
            {
                var user = _manager.SignUp(name, email, password);
                return Created($"/api/AppUsers/{user.Id}", user);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT api/<AppUsersController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<AppUsersController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
