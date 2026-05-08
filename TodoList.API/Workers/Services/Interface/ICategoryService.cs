using System.Collections.Immutable;
using TodoList.API.Models.Dtos.Category;

namespace TodoList.API.Workers.Services.Interface
{
    public interface ICategoryService
    {
        public Task<CategoryResponseDto> CreateAsync(CategoryRequestDto request);
        public Task <CategoryResponseDto> UpdateAsync(CategoryRequestDto request);
        public Task<CategoryResponseDto> DeleteAsync(Guid id);
        public Task<ImmutableList<CategoryResponseDto>> GetAllAsync();
        public Task<CategoryResponseDto> GetByIdAsync(Guid id);

    }
}
