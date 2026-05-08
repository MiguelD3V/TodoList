using System.Collections.Immutable;
using TodoList.API.Models.Entities;

namespace TodoList.API.Data.Interfaces
{
    public interface ICategoryRepository
    {
        public Task<Category> CreateCategoryAsync(Category category);
        public Task<Category> UpdateCategoryAsync(Category category);
        public Task<Category> DeleteCategoryAsync(Category category);
        public Task<ImmutableList<Category>> GetAllCategoriesAsync();
        public Task<Category> GetCategoryByIdAsync(Guid id);
    }
}
