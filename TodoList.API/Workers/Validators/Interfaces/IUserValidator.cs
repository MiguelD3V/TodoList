using TodoList.API.Models.Dtos.User;
using TodoList.API.Models.Entities;

namespace TodoList.API.Workers.Validators.Interfaces
{
    public interface IUserValidator
    {
        public Task<UserResponseDto> ValidateDefault(UserRequestDto request);

    }
}
