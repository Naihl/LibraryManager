
using BusinessObjects.Entity;


namespace DataAccessLayer.Repository
{
    public interface IGenericRepository<T>
    {
        public IEnumerable<T> GetAll();

        public T Get(int id);
    }

}