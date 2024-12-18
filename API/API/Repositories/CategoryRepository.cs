using API.Data;
using API.Data.Entities;
using API.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace API.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly DataContext _context;

        public CategoryRepository(DataContext context)
        {
            _context = context;
        }

        public void AddCategory(Category category)
        {
            _context.Categories.Add(category);
        }

        public void DeleteCategory(Category category)
        {
            _context.Categories.Remove(category);
        }

        public async Task<Category> GetCategoryByIdAsync(int id)
        {
            return await _context.Categories.FindAsync(id);
        }

        public async Task<List<Category>> GetCategoryListAsync()
        {
            return await _context.Categories.ToListAsync();
        }

        public async Task<bool> SaveAllAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        public void UpdateCategory(Category category)
        {
            _context.Entry(category).State = EntityState.Modified;
        }
    }
}
