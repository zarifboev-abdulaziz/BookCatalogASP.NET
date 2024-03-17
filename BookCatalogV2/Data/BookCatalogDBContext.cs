using BookCatalogv2.Models;
using Microsoft.EntityFrameworkCore;

namespace BookCatalogv2.Data
{
    public class BookCatalogDBContext : DbContext
    {
        public BookCatalogDBContext(DbContextOptions<BookCatalogDBContext> options) : base(options) { }
        public DbSet<Book> Books { get; set; }
        public DbSet<Category>? Categories { get; set; }


    }
}
