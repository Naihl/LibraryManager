using BusinessObjects.Entity;
using DataAccessLayer.Repository;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Services.Services;


internal class Program
{
    private static IHost CreateHostBuilder()
    {
        return Host.CreateDefaultBuilder()
            .ConfigureServices(services =>
            {
                // Configuration des services
                // En gros: on remplace tous les "appels" à l'interface générique par la vraie interface
                // à tous les endroits où elle est appelée
                services.AddScoped<IGenericRepository<Book>, BookRepository>();
                // services.AddScoped<IGenericRepository<Author>, AuthorRepository>();
            })
            .Build();
    }


    private static void Main(string[] args)
    {

        // Utilisation de BookRepository avec IHost
        IHost host = CreateHostBuilder();
        CatalogManager catalogManager = new CatalogManager(host.Services.GetRequiredService<IGenericRepository<Book>>());
        // au lieu de
        // CatalogManager catalogManager = new CatalogManager(new BookRepository());


        IEnumerable<Book> aventureBooks = catalogManager.GetCatalog(Book.TypeBook.Aventure);

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
        Author authorById = authorRepository.Get(1);
        if (authorById != null)
        {
            Console.WriteLine($"Author with ID 1: {authorById.LastName}");
        }
    }
}