using Microsoft.AspNetCore.Mvc;
using personapi_dotnet.Controllers.Interfaces;
using personapi_dotnet.Models.Entities;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace personapi_dotnet.Controllers.API
{
    [Route("api/apiestudio")]
    [ApiController]
    public class APIEstudioController : ControllerBase
    {
        private readonly IEstudioRepository _repository;

        public APIEstudioController(IEstudioRepository repository)
        {
            _repository = repository;
        }

        // GET: api/apiestudio
        [HttpGet]
        public ActionResult<IEnumerable<Estudio>> GetEstudios()
        {
            var estudios = _repository.GetAllEstudios();
            return Ok(estudios);
        }

        // GET: api/apiestudio/5
        [HttpGet("{idProf}/{ccPer}")]
        public ActionResult<Estudio> GetEstudio(int idProf, int ccPer)
        {
            var estudio = _repository.GetEstudio(idProf, ccPer);

            if (estudio == null)
            {
                return NotFound();
            }

            return estudio;
        }

        // PUT: api/apiestudio/5
        [HttpPut("{idProf}/{ccPer}")]
        public IActionResult PutEstudio(int idProf, int ccPer, [FromBody] Estudio estudio)
        {
            if (idProf != estudio.IdProf || ccPer != estudio.CcPer)
            {
                return BadRequest();
            }

            _repository.UpdateEstudio(estudio);

            return NoContent();
        }

        // POST: api/apiestudio
        [HttpPost]
        public ActionResult<Estudio> PostEstudio([FromBody] Estudio estudio)
        {
            _repository.AddEstudio(estudio);

            return CreatedAtAction(nameof(GetEstudio), new { idProf = estudio.IdProf, ccPer = estudio.CcPer }, estudio);
        }

        // DELETE: api/apiestudio/5
        [HttpDelete("{idProf}/{ccPer}")]
        public IActionResult DeleteEstudio(int idProf, int ccPer)
        {
            var estudio = _repository.GetEstudio(idProf, ccPer);
            if (estudio == null)
            {
                return NotFound();
            }

            _repository.DeleteEstudio(idProf, ccPer);

            return NoContent();
        }
    }
}
