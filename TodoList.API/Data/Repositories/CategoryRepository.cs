using Microsoft.EntityFrameworkCore;
using System.Collections.Immutable;
using System.Security.Principal;
using TodoList.API.Data.Interfaces;
using TodoList.API.Models.Entities;

namespace TodoList.API.Data.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly AppDbContext _context;

        public CategoryRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<Category> CreateCategoryAsync(Category category)
        {
            _context.Categories.Add(category);
            await _context.SaveChangesAsync();
            var createdCategory = await _context.Categories.FindAsync(category.Id);
            return createdCategory!;
        }

        public async Task<Category> DeleteCategoryAsync(Category category)
        {
            _context.Categories.Remove(category);
            await _context.SaveChangesAsync();
            return category ?? throw new Exception("Falha ao deletar a categoria");
        }

        public async Task<ImmutableList<Category>> GetAllCategoriesAsync()
        {
            var category = await _context.Categories.ToListAsync();
            return category.ToImmutableList();
        }

        public async Task<Category> GetCategoryByIdAsync(Guid id)
        {
            var category = await _context.Categories.FirstOrDefaultAsync(c => c.Id == id);
            return category ?? throw new Exception("Categoria não encontrada");
        }

        public async Task<Category> UpdateCategoryAsync(Category category)
        {
            _context.Categories.Update(category);
            await _context.SaveChangesAsync();
            return category;
        }
    }
}
