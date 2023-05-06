using LocalWise.Data;
using LocalWise.Interfaces;
using LocalWise.Models;
using Microsoft.EntityFrameworkCore;

namespace LocalWise.Repository
{
    public class TuristaRepository : ITuristaRepository
    {
        private LWDbContext _context;

        public TuristaRepository(LWDbContext context)
        {
            _context = context;
        }
        public bool Add(Turista t)
        {
            _context.Add(t);
            return Save();
        }

        public bool Delete(Turista t)
        {
            _context.Remove(t);
            return Save();
        }

        public async Task<IEnumerable<Turista>> GetAll()
        {
            return await _context.Turistas.ToListAsync();
        }

        public async Task<Turista> GetByIdAsync(int id)
        {
            return await _context.Turistas.FirstOrDefaultAsync(i => i.Id == id);
        }

        public async Task<IEnumerable<Turista>> GetByName(string name)
        {
            return await _context.Turistas.Where(c => c.Pessoa.UserName.Contains(name)).ToListAsync();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool Update(Turista t)
        {
            _context.Update(t);
            return Save();
        }
    }
}
