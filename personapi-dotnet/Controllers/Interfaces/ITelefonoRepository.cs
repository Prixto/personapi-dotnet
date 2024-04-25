using personapi_dotnet.Models.Entities;

namespace personapi_dotnet.Controllers.Interfaces
{
    public interface ITelefonoRepository
    {
        Telefono GetTelefono(string num);
        void AddTelefono(Telefono telefono);
        void UpdateTelefono(Telefono telefono);
        void DeleteTelefono(string num);
        IEnumerable<Telefono> GetAllTelefonos();
    }
}
