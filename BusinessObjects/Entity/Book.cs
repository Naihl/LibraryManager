

using BusinessObjects.Entity;

public partial class Book : IEntity
{
    public int Id { get; set; }

    public int Pages, Rate;
    public string? Name { get; set; }


    //https://learn.microsoft.com/en-us/ef/core/modeling/relationships/one-to-many
    public Author Author { get; set; } = null!;
    public IEnumerable<Library> Libraries { get; set; } = null!;

    public TypeBook? Type { get; set; }

}