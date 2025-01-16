//using System.Collections.Generic;
//using BusinessObjects.Entity;

//namespace DataAccessLayer.Repository
//{
//    public class AuthorRepository : IGenericRepository<Author>
//    {
//        private readonly List<Author> _authors;

//        public AuthorRepository()
//        {
//            _authors = new List<Author>
//            {
//                new Author("Franck","Dive"),
//                new Author("George","Lucas"),
//                new Author("J.R.R.","Tolkien")

//            };
//        }

//        public IEnumerable<Author> GetAll()
//        {
//            return _authors;
//        }

//        public Author Get(int id)
//        {
//            return _authors[id];
//        }
//    }
//}