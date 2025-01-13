

using BusinessObjects.Entity;

public class Book(string name, Book.TypeBook typeBook): IEntity
{
    public int Id { get; set; }

    public int Pages, Rate, IdAuthor;
    public string Name { get; set; } = name;
    public TypeBook Type = typeBook;
    public Library? Library { get; set; } = null;

    public enum TypeBook { Fiction, Aventure, SF };

}