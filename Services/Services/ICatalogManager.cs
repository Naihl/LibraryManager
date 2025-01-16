
using DataAccessLayer.Repository;
using BusinessObjects.Entity;

namespace Services.Services
{
    public interface ICatalogManager<Book>
    {
        IEnumerable<Book> GetCatalog();
        IEnumerable<Book> GetCatalog(TypeBook type);
        Book Find(int id);
    }
}