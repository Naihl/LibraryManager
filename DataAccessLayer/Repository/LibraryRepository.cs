using System.Collections.Generic;
using BusinessObjects.Entity;

namespace DataAccessLayer.Repository
{
    public class LibraryRepository : IGenericRepository<Library>
    {
        private readonly List<Library> _library;

        public LibraryRepository()
        {
            _library = new List<Library>
            {
                new Library("Bibliothèque d'Opale Sud", "4 rue Francis Pacuhet 62600 Berck", new BookRepository().GetAll() )

            };
        }

        public IEnumerable<Library> GetAll()
        {
            return _library;
        }

        public Library? Get(int id)
        {
            if (id < 0 || id >= _library.Count)
            {
                return null;
            }
            return _library[id];
        }
    }
}