
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
app.MapGet("/books/{id}", bookController.GetBookById)
.WithName("GetBook")
.WithOpenApi();
app.MapGet("/books/{type}", bookController.GetBooksByType)
.WithName("GetBooksByType")
.WithOpenApi();
app.MapPost("/book/add", bookController.add)
.WithName("AddBook")
.WithOpenApi();


// TODO - L'enum est bugguée

app.Run();