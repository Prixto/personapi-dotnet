using personapi_dotnet.Models.Entities;
using personapi_dotnet.Controllers.Interfaces;

namespace personapi_dotnet.Repositories
{
    public class PersonaRepository : IPersonaRepository
    {
        private readonly PersonaDbContext _context;

        public PersonaRepository(PersonaDbContext context)
        {
            _context = context;
        }

        public Persona GetPersona(int cc)
        {
            return _context.Personas.Find(cc);
        }

        public void AddPersona(Persona persona)
        {
            _context.Personas.Add(persona);
            _context.SaveChanges();
        }

        public void UpdatePersona(Persona persona)
        {
            _context.Personas.Update(persona);
            _context.SaveChanges();
        }

        public void DeletePersona(int cc)
        {
            var persona = _context.Personas.Find(cc);
            if (persona != null)
            {
                _context.Personas.Remove(persona);
                _context.SaveChanges();
            }
        }

        public IEnumerable<Persona> GetAllPersonas()
        {
            return _context.Personas.ToList();
        }
    }
}
