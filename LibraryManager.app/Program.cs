
internal class Program
{
    private static void Main(string[] args)
    {
        // Console.WriteLine("Hello, World!");

        Book[] Library =
        [
            new Book("Pérismer", "Fiction"),
            new Book("Le saigneur des angneaux", "Aventure"),
            new Book("Star Wars", "SF"),
        ];


        foreach (Book book in Library)
        {
            Console.WriteLine(book.Name);
            // Console.WriteLine(book.Type);
        }

    }
}