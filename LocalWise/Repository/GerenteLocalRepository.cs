using LocalWise.Data;
using LocalWise.Interfaces;
using LocalWise.Models;
using Microsoft.EntityFrameworkCore;

namespace LocalWise.Repository
{
    public class GerenteLocalRepository : IGerenteLocalRepository
    {
        public LWDbContext _context;
        public GerenteLocalRepository(LWDbContext context)
        {
            _context = context;
        }
        public bool Add(GerenteLocal gerenteLocal)
        {
            _context.Add(gerenteLocal);
            return Save();
        }

        public bool Delete(GerenteLocal gerenteLocal)
        {
            _context.Remove(gerenteLocal);
            return Save();
        }

        public async Task<IEnumerable<GerenteLocal>> GetAll()
        {
            return await _context.GerenteLocals.ToListAsync();
        }

        public async Task<GerenteLocal> GetByIdAsync(int id)
        {
            return await _context.GerenteLocals.FirstOrDefaultAsync(i => i.Id == id);
        }

        public async Task<GerenteLocal> GetByNameAsync(string razao)
        {
            return await _context.GerenteLocals.FirstOrDefaultAsync(r=>r.RazaoSocial.Contains(razao));
        }

        public async Task<IEnumerable<GerenteLocal>> GetGerenteLocalByCity(string city)
        {
            return await _context.GerenteLocals.Where(c => c.Endereco.Cidade.Contains(city)).ToListAsync();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool Update(GerenteLocal gerenteLocal)
        {
            _context.Update(gerenteLocal);
            return Save();
        }
    }
}
