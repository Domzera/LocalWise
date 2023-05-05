namespace LocalWise.Interfaces
{
    public interface IPhotoRepository
    {
        Task<IPhotoRepository> GetByIdAsync(int id);
        bool Add(IPhotoRepository photo);
        bool Update(IPhotoRepository photo);
        bool Delete(IPhotoRepository photo);
        bool Save();
    }
}
