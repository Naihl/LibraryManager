
using BusinessObjects.Entity;


namespace DataAccessLayer.Repository
{
    public interface IGenericRepository<IEntity>
    {
        public IEnumerable<IEntity> GetAll();

        public IEntity Get(int id);
    }

}