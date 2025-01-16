namespace BusinessObjects.Entity
{
    public class Library : IEntity
    {
        public int Id { get; set; }
        private string Name = "";
        private string Adress = "";
        public IEnumerable<Book> Books { get; set; } = new List<Book>();
    }
}
