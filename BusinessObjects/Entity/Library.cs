using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObjects.Entity
{
    public class Library : IEntity
    {
        public int Id { get; set; }
        private string Name = "";
        private string Adress = "";
        public IEnumerable<Book> Books { get; set; } = new List<Book>();

        public Library(string name, string adress, IEnumerable<Book>? books) : this()
        {
            this.Name = name;
            this.Adress = adress;
            if (books != null)
            {
                this.Books = books;
            }
            else
            {
                this.Books = new List<Book>();
            }
        }

        public Library()
        {
        }
    }
}
