using System.Collections.Immutable;
using TodoList.API.Models.Dtos.User;

namespace TodoList.API.Workers.Services.Interface
{
    public interface IUserService
    {
        public Task<UserResponseDto> CreateAsync(UserRequestDto request);
        public Task<UserResponseDto> UpdateAsync(UserRequestDto request);
        public Task<UserResponseDto> DeleteAsync(UserRequestDto request);
        public Task<UserResponseDto> GetById(Guid id);
        public Task<ImmutableList<UserResponseDto>> GetAllAsync(UserRequestDto request);


    }
}
