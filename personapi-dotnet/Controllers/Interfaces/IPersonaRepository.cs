using personapi_dotnet.Models.Entities;

namespace personapi_dotnet.Controllers.Interfaces
{
    public interface IPersonaRepository
    {
        Persona GetPersona(int cc);
        void AddPersona(Persona persona);
        void UpdatePersona(Persona persona);
        void DeletePersona(int cc);
        IEnumerable<Persona> GetAllPersonas();
    }
}
