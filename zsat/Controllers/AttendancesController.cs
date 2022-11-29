using Microsoft.AspNetCore.Mvc;
using zsat.Interfaces;
using zsat.Managers;
using zsat.Migrations;
using zsat.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace zsat.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AttendancesController : ControllerBase
    {
        private readonly IAttendance _manager;

        public AttendancesController(IAttendance manager)
        {
            _manager = manager;
        }

        // GET: api/<AttendancesController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<AttendancesController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<AttendancesController>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<Attendance> Post(string userId, DateTime timestamp)
        {
            if (userId == null || timestamp == null) return BadRequest();
            try
            {
                var attendace = _manager.RegisterAttendance(userId, timestamp).Result;
                return Created($"/api/Attendances/{attendace.Id}", attendace);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        // PUT api/<AttendancesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<AttendancesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
