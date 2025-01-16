using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BusinessObjects.Entity
{
    public class Author(string firstName, string lastName): IEntity
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = firstName;
        public string LastName { get; set; } = lastName;
        public ICollection<Book> Books { get; set; } = new List<Book>();
    }
}
