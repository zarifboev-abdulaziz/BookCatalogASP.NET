using BookCatalogv2.Data;
using BookCatalogv2.Models;
using Microsoft.EntityFrameworkCore;

namespace BookCatalogv2.Repositories
{
    public class BookRepository : IRepository<Book>
    {
        private readonly BookCatalogDBContext _context;

        public BookRepository(BookCatalogDBContext context)
        {
            _context = context;
        }


        public async Task<IEnumerable<Book>> GetAllAsync()
        {
            return await _context.Books.Include(t => t.Category).ToArrayAsync();
        }


        public async Task AddAsync(Book entity)
        {
            entity.Category = await _context.Categories.FindAsync(entity.CategoryId.Value);
            await _context.Books.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _context.Books.FindAsync(id);
            if (entity != null)
            {
                _context.Books.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }


        public async Task<Book> GetByIDAsync(int id)
        {
            return await _context.Books.Include(t => t.Category).FirstOrDefaultAsync(t => t.Id == id);
        }


        public async Task UpdateAsync(Book entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
