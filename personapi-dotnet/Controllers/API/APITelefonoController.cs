using Microsoft.AspNetCore.Mvc;
using personapi_dotnet.Controllers.Interfaces;
using personapi_dotnet.Models.Entities;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace personapi_dotnet.Controllers.API
{
    [Route("api/apitelefono")]
    [ApiController]
    public class APITelefonoController : ControllerBase
    {
        private readonly ITelefonoRepository _repository;

        public APITelefonoController(ITelefonoRepository repository)
        {
            _repository = repository;
        }

        // GET: api/apitelefono
        [HttpGet]
        public ActionResult<IEnumerable<Telefono>> GetTelefonos()
        {
            var telefonos = _repository.GetAllTelefonos();
            return Ok(telefonos);
        }

        // GET: api/apitelefono/123456789
        [HttpGet("{num}")]
        public ActionResult<Telefono> GetTelefono(string num)
        {
            var telefono = _repository.GetTelefono(num);

            if (telefono == null)
            {
                return NotFound();
            }

            return telefono;
        }

        // PUT: api/apitelefono/123456789
        [HttpPut("{num}")]
        public IActionResult PutTelefono(string num, [FromBody] Telefono telefono)
        {
            if (num != telefono.Num)
            {
                return BadRequest();
            }

            _repository.UpdateTelefono(telefono);

            return NoContent();
        }

        // POST: api/apitelefono
        [HttpPost]
        public ActionResult<Telefono> PostTelefono([FromBody] Telefono telefono)
        {
            _repository.AddTelefono(telefono);

            return CreatedAtAction(nameof(GetTelefono), new { num = telefono.Num }, telefono);
        }

        // DELETE: api/apitelefono/123456789
        [HttpDelete("{num}")]
        public IActionResult DeleteTelefono(string num)
        {
            var telefono = _repository.GetTelefono(num);
            if (telefono == null)
            {
                return NotFound();
            }

            _repository.DeleteTelefono(num);

            return NoContent();
        }
    }
}
