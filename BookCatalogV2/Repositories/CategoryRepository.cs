// Student ID: 00011224
using BookCatalogv2.Data;
using BookCatalogv2.Models;
using Microsoft.EntityFrameworkCore;

namespace BookCatalogv2.Repositories
{
    public class CategoryRepository : IRepository<Category>
    {
        private readonly BookCatalogDBContext _context;
        public CategoryRepository(BookCatalogDBContext context)
        {
            _context = context;
        }



        public async Task AddAsync(Category entity)
        {
            await _context.Categories.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _context.Categories.FindAsync(id);
            if (entity != null)
            {
                _context.Categories.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Category>> GetAllAsync()
        {
            return await _context.Categories.ToArrayAsync();
        }

        public async Task<Category> GetByIDAsync(int id)
        {
            return await _context.Categories.FirstOrDefaultAsync(t => t.Id == id);
        }

        public async Task UpdateAsync(Category entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
