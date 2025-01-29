
using BusinessObjects.Entity;

// same as Book without Rate
public class BookDto : IEntity
{

    public BookDto(Book book)
    {
        Id = book.Id;
        Pages = book.Pages;
        Name = book.Name;
        Author = book.Author;
        Libraries = book.Libraries;
        Type = book.Type;
    }

    public int Id { get; set; }

    public int Pages;
    public string? Name { get; set; }


    //https://learn.microsoft.com/en-us/ef/core/modeling/relationships/one-to-many
    public Author Author { get; set; } = null!;
    public IEnumerable<Library> Libraries { get; set; } = null!;

    public TypeBook? Type { get; set; }

    public static explicit operator BookDto(Book v)
    {
        throw new NotImplementedException();
    }
}