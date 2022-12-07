using Microsoft.AspNetCore.Mvc;
using zsat.Interfaces;
using zsat.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace zsat.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly IStudent _manager;

        public StudentsController(IStudent manager)
        {
            _manager = manager;
        }

        // GET: api/<StudentsController>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<List<Student>> Get()
        {
            var result = _manager.GetAll();
            return Ok(result);
        }

        // GET api/<StudentsController>/5
        [HttpGet("{cardId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<Student> Get(string cardId)
        {
            if (cardId == null) return BadRequest(nameof(cardId));
            try
            {
                var result = _manager.GetByCardId(cardId);
                return Ok(result);
            }
            catch (ArgumentNullException ex)
            {
                return NotFound(ex.Message);
            }
        }

        // POST api/<StudentsController>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public ActionResult<Student> Post(string cardId, string name, string email)
        {
            try
            {
                var student = new Student() { CardId = cardId, Name = name, Email = email };
                var result = _manager.Add(student);
                return Created($"/api/Students/{result.CardId}", result);
            }
            catch (ArgumentNullException ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
