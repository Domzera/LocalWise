using LocalWise.Models;

namespace LocalWise.Interfaces
{
    public interface IPontoTuristicoRepository
    {
        Task<PontoTuristico> GetByIdAsync(int id);
        Task<IEnumerable<PontoTuristico>> GetPontoTuristicoCityAsync(string city);
        Task<IEnumerable<PontoTuristico>> GetByGuiaAsync(string guia);//Talvez não use esse!
        bool Add(PontoTuristico pontoTuristico);
        bool Delete(PontoTuristico pontoTuristico);
        bool Update(PontoTuristico pontoTuristico);
        bool Save();
    }
}
