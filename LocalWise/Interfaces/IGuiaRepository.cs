using LocalWise.Models;

namespace LocalWise.Interfaces
{
    public interface IGuiaRepository
    {
        Task<IEnumerable<Guia>> GetAll();
        Task<Guia> GetByIdAsync(int id);
        Task<Guia> GetByNameAsync(string name);
        Task<IEnumerable<Guia>> GetGuiaByCity(string  city);
        bool Add(Guia guia);
        bool Update(Guia guia);
        bool Delete(Guia guia);
        bool Save();
    }
}
