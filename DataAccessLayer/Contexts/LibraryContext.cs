using Microsoft.EntityFrameworkCore;
using BusinessObjects.Entity;
using System.Collections.Generic;
using System.Reflection.Metadata;

namespace DataAccessLayer.Contexts
{
    public class LibraryContext : DbContext
    {
        public LibraryContext(DbContextOptions<LibraryContext> options) : base(options) { }

        public DbSet<Book> book { get; set; }
        public DbSet<Author> author { get; set; }
        public DbSet<Library> library { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>().ToTable("book")
                .HasOne(x => x.Author).WithMany(x => x.Books)
                .HasForeignKey("id_author");
            
            modelBuilder.Entity<Book>().ToTable("book")
                .HasMany(e => e.Libraries)
                .WithMany(e => e.Books)
                .UsingEntity(
                    "stock",
                    l => l.HasOne(typeof(Library)).WithMany().HasForeignKey("id_library").HasPrincipalKey(nameof(Library.Id)),
                    r => r.HasOne(typeof(Book)).WithMany().HasForeignKey("id_book").HasPrincipalKey(nameof(Book.Id)),
                    j => j.HasKey("id_library", "id_book"));
            

            modelBuilder.Entity<Author>().ToTable("author");

            modelBuilder.Entity<Library>().ToTable("library");

            base.OnModelCreating(modelBuilder);
        }
    }
}
