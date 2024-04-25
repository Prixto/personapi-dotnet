using personapi_dotnet.Controllers.Interfaces;
using personapi_dotnet.Models.Entities;

namespace personapi_dotnet.Repositories
{
    public class EstudioRepository : IEstudioRepository
    {
        private readonly PersonaDbContext _context;

        public EstudioRepository(PersonaDbContext context)
        {
            _context = context;
        }

        public Estudio GetEstudio(int idProf, int ccPer)
        {
            return _context.Estudios.Find(idProf, ccPer);
        }

        public void AddEstudio(Estudio estudio)
        {
            _context.Estudios.Add(estudio);
            _context.SaveChanges();
        }

        public void UpdateEstudio(Estudio estudio)
        {
            _context.Estudios.Update(estudio);
            _context.SaveChanges();
        }

        public void DeleteEstudio(int idProf, int ccPer)
        {
            var estudio = _context.Estudios.Find(idProf, ccPer);
            if (estudio != null)
            {
                _context.Estudios.Remove(estudio);
                _context.SaveChanges();
            }
        }

        public IEnumerable<Estudio> GetAllEstudios()
        {
            return _context.Estudios.ToList();
        }

    }
}
