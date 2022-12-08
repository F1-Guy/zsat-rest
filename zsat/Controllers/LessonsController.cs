using Microsoft.AspNetCore.Mvc;
using zsat.Interfaces;
using zsat.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace zsat.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LessonsController : ControllerBase
    {
        public readonly ILesson _manager;

        public LessonsController(ILesson manager)
        {
            _manager = manager;
        }

        // GET: api/<LessonsController>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<List<Lesson>> Get()
        {
            var result = _manager.GetAll();
            return Ok(result);
        }

        // GET api/<LessonsController>/5
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpGet("{id}")]
        public ActionResult<Lesson> Get(int id)
        {
            if (id == null) return BadRequest(nameof(id));
            try
            {
                var result = _manager.GetById(id);
                return Ok(result);
            }
            catch (ArgumentNullException ex)
            {
                return NotFound(ex.Message);
            }
        }

        // POST api/<LessonsController>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public ActionResult<Lesson> Post(int id, string subject)
        {
            try
            {
                var lesson = new Lesson() { Id = id, Subject = subject };
                var result = _manager.Add(lesson);
                return Created($"/api/Lessons/{result.Id}", result);
            }
            catch (ArgumentNullException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT api/<LessonsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<LessonsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
