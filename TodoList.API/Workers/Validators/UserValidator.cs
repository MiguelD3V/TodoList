using System.Text.RegularExpressions;
using TodoList.API.Models.Dtos.Task;
using TodoList.API.Models.Dtos.User;
using TodoList.API.Workers.Validators.Interfaces;

namespace TodoList.API.Workers.Validators
{
    public class UserValidator : IUserValidator
    {
        public async Task<UserResponseDto> ValidateDefault(UserRequestDto request)
        {
            var response = new UserResponseDto()
            {
                Errors = []
            };

            if(string.IsNullOrEmpty(request.Name))
            {
                response.IsSucess = false;
                response.Errors.Add("Insira um nome para o usuário");
            }
            if (string.IsNullOrEmpty(request.Email))
            {
                response.IsSucess = false;
                response.Errors.Add("Insira um email para o usuário");
            }
            if (!Regex.IsMatch(request.Email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
            {
                response.IsSucess = false;
                response.Errors.Add("Insira um email válido para o usuário");
            }
            if(response.Errors.Count == 0)
            {
                response.IsSucess = true;
            }

            return response;
        }
    }
}
