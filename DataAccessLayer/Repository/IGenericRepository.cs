
using BusinessObjects.Entity;
using Microsoft.EntityFrameworkCore;



namespace DataAccessLayer.Repository
{
    public interface IGenericRepository<T> where T : IEntity
    {
        public IEnumerable<T> GetAll();

        public T Get(int id);

        public T Add(T entity);
    }



}