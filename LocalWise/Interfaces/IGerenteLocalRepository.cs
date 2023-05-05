using LocalWise.Models;

namespace LocalWise.Interfaces
{
    public interface IGerenteLocalRepository
    {
        Task<IEnumerable<GerenteLocal>> GetAll();
        Task<GerenteLocal> GetByIdAsync(int id);
        Task<GerenteLocal> GetByNameAsync(string name);
        Task<IEnumerable<GerenteLocal>> GetGerenteLocalByCity(string city);
        bool Add(GerenteLocal gerenteLocal);
        bool Update(GerenteLocal gerenteLocal);
        bool Delete(GerenteLocal gerenteLocal);
        bool Save();
    }
}
