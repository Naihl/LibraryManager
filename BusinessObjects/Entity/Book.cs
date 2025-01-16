

using BusinessObjects.Entity;

public partial class Book : IEntity
{
    public int Id { get; set; }

    public int Pages, Rate, IdAuthor;
    public string? Name { get; set; }
    public Library? Library { get; set; } = null;

    public TypeBook? Type { get; set; }

}