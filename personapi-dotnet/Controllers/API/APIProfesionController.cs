using Microsoft.AspNetCore.Mvc;
using personapi_dotnet.Controllers.Interfaces;
using personapi_dotnet.Models.Entities;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace personapi_dotnet.Controllers.API
{
    [Route("api/apiprofesion")]
    [ApiController]
    public class APIProfesionController : ControllerBase
    {
        private readonly IProfesionRepository _repository;

        public APIProfesionController(IProfesionRepository repository)
        {
            _repository = repository;
        }

        // GET: api/apiprofesion
        [HttpGet]
        public ActionResult<IEnumerable<Profesion>> GetProfesions()
        {
            var profesions = _repository.GetAllProfesiones();
            return Ok(profesions);
        }

        // GET: api/apiprofesion/5
        [HttpGet("{id}")]
        public ActionResult<Profesion> GetProfesion(int id)
        {
            var profesion = _repository.GetProfesion(id);

            if (profesion == null)
            {
                return NotFound();
            }

            return profesion;
        }

        // PUT: api/apiprofesion/5
        [HttpPut("{id}")]
        public IActionResult PutProfesion(int id, [FromBody] Profesion profesion)
        {
            if (id != profesion.Id)
            {
                return BadRequest();
            }

            _repository.UpdateProfesion(profesion);

            return NoContent();
        }

        // POST: api/apiprofesion
        [HttpPost]
        public ActionResult<Profesion> PostProfesion([FromBody] Profesion profesion)
        {
            _repository.AddProfesion(profesion);

            return CreatedAtAction(nameof(GetProfesion), new { id = profesion.Id }, profesion);
        }

        // DELETE: api/apiprofesion/5
        [HttpDelete("{id}")]
        public IActionResult DeleteProfesion(int id)
        {
            var profesion = _repository.GetProfesion(id);
            if (profesion == null)
            {
                return NotFound();
            }

            _repository.DeleteProfesion(id);

            return NoContent();
        }
    }
}
