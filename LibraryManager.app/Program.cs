using System;
using System.Collections.Generic;
using System.Linq;

internal class Program
{
    private static void Main(string[] args)
    {
        // Console.WriteLine("Hello, World!");

        Book[] library =
        [
            new Book("Pérismer", "Fiction"),
            new Book("Le Seigneur des anneaux", "Aventure"),
            new Book("Star Wars", "SF"),
        ];

        IEnumerable<Book> aventureBooks = from Book in library
                                          where Book.Type == "Aventure"
                                          select Book;



        foreach (Book book in aventureBooks)
        {
            Console.WriteLine(book.Name);
            // Console.WriteLine(book.Type);
        }

    }
}