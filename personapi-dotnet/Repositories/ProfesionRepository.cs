using personapi_dotnet.Controllers.Interfaces;
using personapi_dotnet.Models.Entities;

namespace personapi_dotnet.Repositories
{
    public class ProfesionRepository : IProfesionRepository
    {
        private readonly PersonaDbContext _context;

        public ProfesionRepository(PersonaDbContext context)
        {
            _context = context;
        }

        public Profesion GetProfesion(int id)
        {
            return _context.Profesions.Find(id);
        }

        public void AddProfesion(Profesion profesion)
        {
            _context.Profesions.Add(profesion);
            _context.SaveChanges();
        }

        public void UpdateProfesion(Profesion profesion)
        {
            _context.Profesions.Update(profesion);
            _context.SaveChanges();
        }

        public void DeleteProfesion(int id)
        {
            var profesion = _context.Profesions.Find(id);
            if (profesion != null)
            {
                _context.Profesions.Remove(profesion);
                _context.SaveChanges();
            }
        }

        public IEnumerable<Profesion> GetAllProfesiones()
        {
            return _context.Profesions.ToList();
        }
    }
}
