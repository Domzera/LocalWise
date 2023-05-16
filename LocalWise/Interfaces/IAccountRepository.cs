using LocalWise.Models;

namespace LocalWise.Interfaces
{
    public interface IAccountRepository
    {
        Task<IEnumerable<Pessoa>> GetAll();

        Task<IEnumerable<Pessoa>> API_GetAll();
        Task<Pessoa> GetByIdAsync(string id);
        Task<Pessoa> GetByNameAsync(string name);
        //Task<IEnumerable<Pessoa>> GetGuiaByCity(string  city);
        bool Add(Pessoa pessoa);
        bool Update(Pessoa pessoa);
        bool Delete(Pessoa pessoa);
        bool Save();
    }
}
