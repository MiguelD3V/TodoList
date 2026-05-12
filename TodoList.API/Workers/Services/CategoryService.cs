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
            var findCategory = await _categoryRepository.GetCategoryByIdAsync(id);
            if (findCategory == null) 
            {
                throw new Exception("A categoria não foi encontrada");
            }
            await _categoryRepository.DeleteCategoryAsync(findCategory);

            return new CategoryResponseDto()
            {
                IsSucess = true,
                Data = findCategory
            };
        }

        public async Task<ImmutableList<CategoryResponseDto>> GetAllAsync()
        {
            var categories = await _categoryRepository.GetAllCategoriesAsync();

            return categories
                .Select(categories => new CategoryResponseDto()
                {
                   IsSucess = true,
                   Data = categories
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
                IsSucess = true,
                Data = category
            };
        }

        public async Task<CategoryResponseDto> UpdateAsync(Guid id, CategoryRequestDto request)
        {
            var findCategory = await _categoryRepository.GetCategoryByIdAsync(id);
            if (findCategory == null)
            {
                throw new Exception("A categoria não foi encontrada");
            }

            var validationResult = await _categoryValidator.ValidateDefault(request);
            if (!validationResult.IsSucess)
            {
                return new CategoryResponseDto()
                {
                    IsSucess = false,
                    Errors = validationResult.Errors
                };
            }

            findCategory.Name = request.Name;

            await _categoryRepository.UpdateCategoryAsync(findCategory);

            return new CategoryResponseDto()
            {
                IsSucess = true,
                Data = findCategory
            };
        }
    }
}
