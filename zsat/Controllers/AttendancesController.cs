using Microsoft.AspNetCore.Mvc;
using zsat.Interfaces;
using zsat.Managers;
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
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public ActionResult<IEnumerable<Attendance>> Get()
        {
            List<Attendance> attendances = _manager.GetAllAttendances();
            if (attendances == null)
                return NoContent();
            return attendances;
        }

        // GET api/<AttendancesController>/5
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<Attendance> Get(int id)
        {
            try
            {
                return Ok(_manager.GetById(id));
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
           
        }

        // POST api/<AttendancesController>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<Attendance> Post(string cardId, DateTime timestamp, int lessonId)
        {
            try
            {
                var attendace = _manager.RegisterAttendance(cardId, timestamp, lessonId);
                return Created($"/api/Attendances/{attendace.Id}", attendace);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
        [HttpGet]
        [Route("[action]")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<List<Attendance>> Filter(DateTime startDate, int lessonId, DateTime endDate)
        {
            try
            {
                List<Attendance> filtered = _manager.Filter(startDate, lessonId, endDate);
                return Ok(filtered);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE api/<AttendancesController>/5
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult Delete(int id)
        {
            try
            {
                Attendance toDelete = _manager.DeleteAttendance(id);
                return Ok(toDelete);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
