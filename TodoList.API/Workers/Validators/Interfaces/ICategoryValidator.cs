using TodoList.API.Models.Dtos.Category;

namespace TodoList.API.Workers.Validators.Interfaces
{
    public interface ICategoryValidator
    {
        public Task<CategoryResponseDto> ValidateDefault(CategoryRequestDto categoryRequestDto);        
    }
}
