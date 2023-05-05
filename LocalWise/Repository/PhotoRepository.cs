using LocalWise.Data;
using LocalWise.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace LocalWise.Repository
{
    public class PhotoRepository : IPhotoRepository
    {
        public LWDbContext _context;
        public PhotoRepository(LWDbContext context)
        {
            _context = context;
        }

        public bool Add(IPhotoRepository photo)
        {
            _context.Add(photo);
            return Save();
        }

        public bool Delete(IPhotoRepository photo)
        {
            _context.Remove(photo);
            return Save();
        }

        public async Task<IPhotoRepository> GetByIdAsync(int id)
        {
            return (IPhotoRepository)await _context.Photos.FirstOrDefaultAsync(i => i.Id == id);
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool Update(IPhotoRepository photo)
        {
            _context.Update(photo);
            return Save();
        }
    }
}
