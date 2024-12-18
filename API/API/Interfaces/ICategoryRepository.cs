using API.Data.Entities;

namespace API.Interfaces
{
    public interface ICategoryRepository
    {
        Task<Category> GetCategoryByIdAsync(int id);
        Task<List<Category>> GetCategoryListAsync();

        Task<bool> SaveAllAsync();
        void AddCategory(Category category);
        void UpdateCategory(Category category);
        void DeleteCategory(Category category);
    }
}
