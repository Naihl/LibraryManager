using System.Collections.Generic;
using BusinessObjects.Entity;

namespace DataAccessLayer.Repository
{
    public class AuthorRepository
    {
        private readonly List<Author> _authors;

        public AuthorRepository()
        {
            _authors = new List<Author>
            {
                new Author("Franck","Dive"),
                new Author("George","Lucas"),
                new Author("J.R.R.","Tolkien")

            };
        }

        public IEnumerable<Author> GetAll()
        {
            return _authors;
        }

        public Author? Get(int id)
        {
            if (id < 0 || id >= _authors.Count)
            {
                return null;
            }
            return _authors[id];
        }
    }
}