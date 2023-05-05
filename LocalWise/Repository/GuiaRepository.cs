using LocalWise.Data;
using LocalWise.Interfaces;
using LocalWise.Models;
using Microsoft.EntityFrameworkCore;

namespace LocalWise.Repository
{
    public class GuiaRepository : IGuiaRepository//Aqui o IGuiaRepository está sendo implementado
    {
        private LWDbContext _context;

        public GuiaRepository(LWDbContext context)
        {
            _context = context;
        }
        public bool Add(Guia guia)
        {
            _context.Add(guia);
            return Save();
        }

        public bool Delete(Guia guia)
        {
            _context.Remove(guia);
            return Save();
        }

        public bool Update(Guia guia)
        {
            _context.Update(guia);
            return Save();
        }

        public async Task<IEnumerable<Guia>> GetAll()
        {
            return await _context.Guias.Include(t=>t.Pessoa).ToListAsync();
        }

        public async Task<Guia> GetByIdAsync(int id)
        {
            return await _context.Guias.FirstOrDefaultAsync(i => i.Id == id);
        }

        public async Task<Guia> GetByNameAsync(string name)
        {
            return await _context.Guias.FirstOrDefaultAsync(n => n.Pessoa.Nome.Contains(name));
        }

        public async Task<IEnumerable<Guia>> GetGuiaByCity(string city)
        {
            return await _context.Guias.Where(c=>c.GerenteLocal.Endereco.Cidade.Contains(city)).ToListAsync();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }
    }
}
