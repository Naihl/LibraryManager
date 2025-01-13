using System;
using System.Collections.Generic;
using System.Linq;
using BusinessObjects.Entity;
using DataAccessLayer.Repository;

internal class Program
{
    private static void Main(string[] args)
    {
        // Utilisation de BookRepository
        BookRepository bookRepository = new BookRepository();
        IEnumerable<Book> library = bookRepository.GetAll();

        IEnumerable<Book> aventureBooks = from book in library
                                          where book.Type == Book.TypeBook.Aventure
                                          select book;

        foreach (Book book in aventureBooks)
        {
            Console.WriteLine(book.Name);
        }

        // Utilisation de AuthorRepository
        AuthorRepository authorRepository = new AuthorRepository();
        IEnumerable<Author> authors = authorRepository.GetAll();

        foreach (Author author in authors)
        {
            Console.WriteLine(author.LastName);
        }

        // Exemple d'utilisation de Get(int id) pour Author
        Author? authorById = authorRepository.Get(1);
        if (authorById != null)
        {
            Console.WriteLine($"Author with ID 1: {authorById.LastName}");
        }
    }
}