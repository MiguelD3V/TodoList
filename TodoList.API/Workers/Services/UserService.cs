using System.Collections.Immutable;
using TodoList.API.Data.Interfaces;
using TodoList.API.Models.Dtos.User;
using TodoList.API.Workers.Services.Interface;
using TodoList.API.Workers.Validators.Interfaces;

namespace TodoList.API.Workers.Services
{
    public class UserService : IUserService
    {
        
        private readonly IUserRepository _userRepository;
        private readonly IUserValidator _userValidator;

        public UserService(IUserRepository userRepository, IUserValidator userValidator)
        {
            _userRepository = userRepository;
            _userValidator = userValidator;
        }

        public Task<UserResponseDto> CreateAsync(UserRequestDto request)
        {
            throw new NotImplementedException();
        }

        public Task<UserResponseDto> DeleteAsync(UserRequestDto request)
        {
            throw new NotImplementedException();
        }

        public Task<ImmutableList<UserResponseDto>> GetAllAsync(UserRequestDto request)
        {
            throw new NotImplementedException();
        }

        public Task<UserResponseDto> GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<UserResponseDto> UpdateAsync(UserRequestDto request)
        {
            throw new NotImplementedException();
        }
    }
}
