using LocalWise.Data;
using LocalWise.Interfaces;
using LocalWise.Models;
using Microsoft.EntityFrameworkCore;

namespace LocalWise.Repository
{
    public class PontoTuristicoRepository : IPontoTuristicoRepository
    {
        public LWDbContext _context;
        public PontoTuristicoRepository(LWDbContext context)
        {
            _context = context;
        }
        public bool Add(PontoTuristico pontoTuristico)
        {
            _context.Add(pontoTuristico);
            return Save();
        }

        public bool Delete(PontoTuristico pontoTuristico)
        {
            _context.Remove(pontoTuristico);
            return Save();
        }

        public async Task<IEnumerable<PontoTuristico>> GetByGuiaAsync(int guiaId)
        {
            //Aqui foi implementado pelo VSC - Visual Studi Code
            return (IEnumerable<PontoTuristico>)await _context.PontoTuristicos.FirstOrDefaultAsync(i => i.GuiaId == guiaId);
        }

        public Task<IEnumerable<PontoTuristico>> GetByGuiaAsync(string guia)
        {
            //Não implementado ainda
            throw new NotImplementedException();
        }

        public async Task<PontoTuristico> GetByIdAsync(int id)
        {
            return await _context.PontoTuristicos.FirstOrDefaultAsync(i => i.Id == id);
        }

        public async Task<IEnumerable<PontoTuristico>> GetPontoTuristicoCityAsync(string city)
        {
            //Aqui foi implementado pelo VSC - Visual Studi Code
            return (IEnumerable<PontoTuristico>)await _context.PontoTuristicos.Include(i=>i.Endereco).FirstOrDefaultAsync(i => i.Endereco.Cidade == city);
        }

        public bool Save()
        {
            var saved =_context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool Update(PontoTuristico pontoTuristico)
        {
            _context.Update(pontoTuristico);
            return Save();
        }
    }
}
