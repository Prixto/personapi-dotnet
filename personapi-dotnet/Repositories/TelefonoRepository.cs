using personapi_dotnet.Controllers.Interfaces;
using personapi_dotnet.Models.Entities;

namespace personapi_dotnet.Repositories
{
    public class TelefonoRepository : ITelefonoRepository
    {
        private readonly PersonaDbContext _context;

        public TelefonoRepository(PersonaDbContext context)
        {
            _context = context;
        }

        public Telefono GetTelefono(string num)
        {
            return _context.Telefonos.Find(num);
        }

        public void AddTelefono(Telefono telefono)
        {
            _context.Telefonos.Add(telefono);
            _context.SaveChanges();
        }

        public void UpdateTelefono(Telefono telefono)
        {
            _context.Telefonos.Update(telefono);
            _context.SaveChanges();
        }

        public void DeleteTelefono(string num)
        {
            var telefono = _context.Telefonos.Find(num);
            if (telefono != null)
            {
                _context.Telefonos.Remove(telefono);
                _context.SaveChanges();
            }
        }

        public IEnumerable<Telefono> GetAllTelefonos()
        {
            return _context.Telefonos.ToList();
        }
    }
}
