using Microsoft.AspNetCore.Mvc;
using personapi_dotnet.Controllers.Interfaces;
using personapi_dotnet.Models.Entities;
using personapi_dotnet.Repositories;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace personapi_dotnet.Controllers.API
{
    [Route("api/apipersona")]
    [ApiController]
    public class APIPersonaController : ControllerBase
    {
        private readonly IPersonaRepository _personaRepository;

        public APIPersonaController(IPersonaRepository personaRepository)
        {
            _personaRepository = personaRepository;
        }

        [HttpGet("{cc}")]
        public ActionResult<Persona> Get(int cc)
        {
            var persona = _personaRepository.GetPersona(cc);
            if (persona == null)
            {
                return NotFound();
            }
            return Ok(persona);
        }

        [HttpPost]
        public ActionResult<Persona> Post([FromBody] Persona persona)
        {
            _personaRepository.AddPersona(persona);
            return CreatedAtAction(nameof(Get), new { cc = persona.Cc }, persona);
        }

        [HttpPut("{cc}")]
        public ActionResult<Persona> Put(int cc, [FromBody] Persona persona)
        {
            if (cc != persona.Cc)
            {
                return BadRequest();
            }

            _personaRepository.UpdatePersona(persona);

            return NoContent();
        }

        [HttpDelete("{cc}")]
        public ActionResult<Persona> Delete(int cc)
        {
            var persona = _personaRepository.GetPersona(cc);
            if (persona == null)
            {
                return NotFound();
            }

            _personaRepository.DeletePersona(cc);

            return NoContent();
        }

        [HttpGet]
        public ActionResult<IEnumerable<Persona>> GetAll()
        {
            var personas = _personaRepository.GetAllPersonas();
            return Ok(personas);
        }
    }
}
