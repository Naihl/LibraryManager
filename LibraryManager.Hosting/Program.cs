
using BusinessObjects.Entity;
using DataAccessLayer.Repository;
using Microsoft.EntityFrameworkCore;
using Services.Services;
using DataAccessLayer.Contexts;
using LibraryManager.Hosting.Controllers;


IHost CreateHostBuilder()
{
    return Host.CreateDefaultBuilder()
    .ConfigureServices(services =>
    {
        var dbPath = Path.Combine(Directory.GetCurrentDirectory(), "library.db");
        services.AddDbContext<LibraryContext>(options =>
        options.UseSqlite($"Data Source={dbPath};"));
        services.AddScoped<IGenericRepository<Book>, GenericRepository<Book>>();
        services.AddScoped<IGenericRepository<Author>, GenericRepository<Author>>();
        services.AddScoped<IGenericRepository<Library>, GenericRepository<Library>>();
        services.AddScoped<ICatalogManager<Book>, CatalogManager>();
    })
    .Build();
}


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();


IHost host = CreateHostBuilder();
ICatalogManager<Book> catalogManager = host.Services.GetRequiredService<ICatalogManager<Book>>();
IEnumerable<Book> aventureBooks = catalogManager.GetCatalog(TypeBook.Aventure);


BookController bookController = new BookController(catalogManager);

app.MapGet("/books", bookController.GetAllBooks)
    .WithName("GetAllBooks")
    .WithOpenApi();
app.MapGet("/books/{id:int}", bookController.GetBookById)
    .WithName("GetBook")
    .WithOpenApi();

// hack pour se conformer au sujet (i.e. ne pas faire de /books/type/{type})
app.MapGet("/books/{type:regex(^[a-zA-Z]+$)}", bookController.GetBooksByType)
    .WithName("GetBooksByType")
    .WithOpenApi();

app.MapPost("/book/add", bookController.Add)
    .WithName("AddBook")
    .WithOpenApi();


// Erreur connues :
// - les requêtes BDD sur les Book n'utilisent pas la jointure avec Author, renvoyant null sur les appels 
// aux api /books et /books/{id}
// - /books/type renvoie une liste vide même sur une requête censée renvoyer des résultats
// - sur la page du swagger, le schéma Book est visible en plus de BookDto

// console log swagger url
Console.WriteLine($"Swagger UI: /swagger");


app.Run();