using LocalWise.Models;

namespace LocalWise.Interfaces
{
    public interface ITuristaRepository
    {
        Task<IEnumerable<Turista>> GetAll();
        Task<Turista> GetByIdAsync(int id);
        Task<IEnumerable<Turista>> GetByName(string name);
        bool Add(Turista t);
        bool Update(Turista t);
        bool Delete(Turista t);
        bool Save();
    }
}
