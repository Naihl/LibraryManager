using BusinessObjects.Entity;
using DataAccessLayer.Repository;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using Services.Services;
using DataAccessLayer.Contexts;


internal class Program
{
    private static IHost CreateHostBuilder()
    {
        return Host.CreateDefaultBuilder()
            .ConfigureServices(services =>
            {
                var dbPath = Path.Combine(Directory.GetCurrentDirectory(), "library.db");
                services.AddDbContext<LibraryContext>(options =>
                options.UseSqlite($"Data Source={dbPath};"));
                // Configuration des services
                // En gros: on remplace tous les "appels" à l'interface générique par la vraie interface
                // à tous les endroits où elle est appelée
                services.AddScoped<IGenericRepository<Book>, GenericRepository<Book>>();
                services.AddScoped<IGenericRepository<Author>, GenericRepository<Author>>();
                services.AddScoped<IGenericRepository<Library>, GenericRepository<Library>>();
                services.AddScoped<ICatalogManager<Book>, CatalogManager>();
            })
            .Build();
    }


    private static void Main(string[] args)
    {

        // Utilisation de BookRepository avec IHost
        IHost host = CreateHostBuilder();
        // CatalogManager catalogManager = new CatalogManager(host.Services.GetRequiredService<IGenericRepository<Book>>());
        ICatalogManager<Book> catalogManager = host.Services.GetRequiredService<ICatalogManager<Book>>();
        // au lieu de
        // CatalogManager catalogManager = new CatalogManager(new BookRepository());


        IEnumerable<Book> aventureBooks = catalogManager.GetCatalog(TypeBook.Aventure);

        foreach (Book book in aventureBooks)
        {
            Console.WriteLine(book.Name);
        }

        // Utilisation de AuthorRepository
        IGenericRepository<Author> authorRepository = host.Services.GetRequiredService<IGenericRepository<Author>>();
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