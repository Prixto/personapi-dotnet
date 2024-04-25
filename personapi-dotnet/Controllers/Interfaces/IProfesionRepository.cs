using personapi_dotnet.Models.Entities;

namespace personapi_dotnet.Controllers.Interfaces
{
    public interface IProfesionRepository
    {
        Profesion GetProfesion(int id);
        void AddProfesion(Profesion profesion);
        void UpdateProfesion(Profesion profesion);
        void DeleteProfesion(int id);
        IEnumerable<Profesion> GetAllProfesiones();
    }
}
