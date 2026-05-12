using System.Collections.Immutable;
using TodoList.API.Models.Dtos.User;

namespace TodoList.API.Workers.Services.Interface
{
    public interface IUserService
    {
        public Task<UserResponseDto> CreateAsync(UserRequestDto request);
        public Task<UserResponseDto> UpdateAsync(Guid id, UserRequestDto request);
        public Task<UserResponseDto> DeleteAsync(Guid id);
        public Task<UserResponseDto> GetById(Guid id);
        public Task<ImmutableList<UserResponseDto>> GetAllAsync();


    }
}
