using personapi_dotnet.Models.Entities;

namespace personapi_dotnet.Controllers.Interfaces
{
    public interface IEstudioRepository
    {
        Estudio GetEstudio(int idProf, int ccPer);
        void AddEstudio(Estudio estudio);
        void UpdateEstudio(Estudio estudio);
        void DeleteEstudio(int idProf, int ccPer);
        IEnumerable<Estudio> GetAllEstudios();
    }
}
