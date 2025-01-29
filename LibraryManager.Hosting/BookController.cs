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
        public IEnumerable<BookDto> GetAllBooks()
        {
            var books = catalogManager.GetCatalog().Select(book => new BookDto(book)).ToList();
            return books;
        }

        [HttpGet("{id}")]
        public BookDto GetBookById(int id)
        {
            var book = catalogManager.Find(id);
            return new BookDto(book);
        }

        [HttpPost("{type}")]
        public List<BookDto> GetBooksByType(TypeBook type)
        {
            var books = catalogManager.GetCatalog(type).Select(book => new BookDto(book)).ToList();
            return books;
        }

        [HttpPost]
        public void Add(BookDto book)
        {
            catalogManager.Add(new Book
            {
                Id = book.Id,
                Name = book.Name,
                Pages = book.Pages,
                Author = book.Author,
                Libraries = book.Libraries,
                Type = book.Type
            });
        }
    }
}