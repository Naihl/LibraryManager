
using DataAccessLayer.Repository;
using Microsoft.AspNetCore.Mvc;
using Services.Services;


namespace LibraryManager.Hosting.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        public ICatalogManager<Book> catalogManager = null!;
        public BookController(ICatalogManager<Book> catalogManager)
        {
            this.catalogManager = catalogManager;
        }

        [HttpGet]
        public IEnumerable<Book> GetAllBooks()
        {
            var books = catalogManager.GetCatalog().ToList();
            return books;
        }

        [HttpGet("{id}")]
        public Book GetBookById(int id)
        {
            return catalogManager.Find(id);
        }

        [HttpPost("{type}")]
        public List<Book> GetBooksByType(TypeBook type)
        {
            return catalogManager.GetCatalog(type).ToList();
        }

        [HttpPost]
        public void add(Book book)
        {
            catalogManager.Add(book);
        }
    }
}