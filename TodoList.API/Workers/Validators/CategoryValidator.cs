using TodoList.API.Models.Dtos.Category;
using TodoList.API.Workers.Validators.Interfaces;

namespace TodoList.API.Workers.Validators
{
    public class CategoryValidator : ICategoryValidator
    {
        public async Task<CategoryResponseDto> ValidateDefault(CategoryRequestDto request)
        {
            CategoryResponseDto response = new CategoryResponseDto()
            {
                IsSucess = true,
                Errors = []
            };

            if (string.IsNullOrEmpty(request.Name))
            {
                response.IsSucess = false;
                response.Errors.Add("O nome da categoria não pode ser nulo.");
            }
            if (request.Name.Length > 100)
            {
                response.IsSucess = false;
                response.Errors.Add("O nome da categoria não pode conter mais de 100 caracteres.");
            }
            if(request.Name.Length < 3)
            {
                response.IsSucess = false;
                response.Errors.Add("O nome da categoria deve conter pelo menos 3 caracteres.");
            }
            if (response.Errors.Count == 0)
            {
                response.IsSucess = true;
            }

            return response;

        }
    }
}
