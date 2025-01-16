//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using BusinessObjects;
//using DataAccessLayer.Contexts;


//namespace DataAccessLayer.Repository
//{
//    public class BookRepository : IGenericRepository<Book>
//    {
//        private readonly LibraryContext _libraryContext;

//        public BookRepository(LibraryContext context)
//        {

//            _libraryContext = context;
//        }

//        public IEnumerable<Book> GetAll()
//        {
//            return _books;
//        }

//        public Book Get(int id)
//        {
//            return _books[id];
//        }

//    }
//}
