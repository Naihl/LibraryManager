using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObjects;


namespace DataAccessLayer.Repository
{
    public class BookRepository : IGenericRepository<Book>
    {
        private readonly List<Book> _books;

        public BookRepository()
        {
            _books = new List<Book>
            {
                new Book("Pérismer", Book.TypeBook.Fiction),
                new Book("Le Seigneur des anneaux", Book.TypeBook.Aventure),
                new Book("Star Wars", Book.TypeBook.SF)
            };
        }

        public IEnumerable<Book> GetAll()
        {
            return _books;
        }

        public Book Get(int id)
        {
            return _books[id];
        }

    }
}
