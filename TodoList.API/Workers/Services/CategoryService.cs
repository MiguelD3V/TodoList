using System.Collections.Immutable;
using TodoList.API.Data.Interfaces;
using TodoList.API.Models.Dtos.Category;
using TodoList.API.Models.Entities;
using TodoList.API.Workers.Services.Interface;
using TodoList.API.Workers.Validators.Interfaces;

namespace TodoList.API.Workers.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly ICategoryValidator _categoryValidator;

        public CategoryService(ICategoryRepository categoryRepository, ICategoryValidator categoryValidator)
        {
            _categoryRepository = categoryRepository;
            _categoryValidator = categoryValidator;
        }

        public async Task<CategoryResponseDto> CreateAsync(CategoryRequestDto request)
        {
            var validationResult = await _categoryValidator.ValidateDefault(request);

            if (!validationResult.IsSucess)
            {
                return new CategoryResponseDto()
                {
                    IsSucess = false,
                    Errors = validationResult.Errors
                };  
            }

            Category entity = new Category()
            {
                Name = request.Name
            };
            
            await _categoryRepository.CreateCategoryAsync(entity);

            return new CategoryResponseDto()
            {
                IsSucess = true,
                Data = entity
            };
        }

        public async Task<CategoryResponseDto> DeleteAsync(Guid id)
        {
            var findCategory = _categoryRepository.GetCategoryByIdAsync(id);
            await _categoryRepository.DeleteCategoryAsync(findCategory.Result);

            return new CategoryResponseDto()
            {
                IsSucess = true,
                Data = findCategory.Result
            };
        }

        public async Task<ImmutableList<CategoryResponseDto>> GetAllAsync()
        {
            var categories = await _categoryRepository.GetAllCategoriesAsync();

            return categories
                .Select(categories => new CategoryResponseDto()
                {
                    Id = categories.Id,
                    Name = categories.Name
                }).ToImmutableList();
        }

        public async Task<CategoryResponseDto> GetByIdAsync(Guid id)
        {
            var category = await _categoryRepository.GetCategoryByIdAsync(id);
            if (category == null)
            {
                throw new Exception("A categoria não foi encontrada");
            }

            return new CategoryResponseDto()
            {
                Id = category.Id,
                Name = category.Name
            };
        }

        public Task<CategoryResponseDto> UpdateAsync(CategoryRequestDto request)
        {
            throw new NotImplementedException();
        }
    }
}
