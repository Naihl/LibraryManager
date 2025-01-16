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

            Book Perismer = new Book();
            Perismer.Name = "Pérismer";
            Perismer.Type = TypeBook.Fiction;

            Book LeSeigneurDesAnneaux = new Book();
            LeSeigneurDesAnneaux.Name = "Le Seigneur des anneaux";
            LeSeigneurDesAnneaux.Type = TypeBook.Aventure;

            Book StarWars = new Book();
            StarWars.Name = "Star Wars";
            StarWars.Type = TypeBook.SF;


            _books = new List<Book>
            {
                Perismer,
                LeSeigneurDesAnneaux,
                StarWars
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
