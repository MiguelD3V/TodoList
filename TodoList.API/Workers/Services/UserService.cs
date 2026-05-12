using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using TodoList.API.Data.Interfaces;
using TodoList.API.Models.Dtos.User;
using TodoList.API.Models.Entities;
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

        public async Task<UserResponseDto> CreateAsync(UserRequestDto request)
        {
            var validationResult = await _userValidator.ValidateDefault(request);
            if (!validationResult.IsSucess)
            {
                return new UserResponseDto()
                {
                    IsSucess = false,
                    Errors = validationResult.Errors
                };
            }

            User entity = new User()
            {
                Name = request.Name,
                Email = request.Email
            };

            await _userRepository.CreateUserAsync(entity);

            return new UserResponseDto()
            {
                IsSucess = true,
                Data = entity
            };
        }

        public async Task<UserResponseDto> DeleteAsync(Guid id)
        {
            var findUser = await _userRepository.GetUserByIdAsync(id);
            if (findUser == null)
            {
                throw new Exception("Usuário não encontrado.");
            }

            await _userRepository.DeleteUserAsync(findUser);

            return new UserResponseDto()
            {
                IsSucess = true,
                Data = findUser
            };
        }

        public async Task<ImmutableList<UserResponseDto>> GetAllAsync()
        {
            var users = await _userRepository.GetAllUsersAsync();

            return users
                .Select(u => new UserResponseDto()
            {
                IsSucess = true,
                Data = users
            }).ToImmutableList();
        }

        public async Task<UserResponseDto> GetById(Guid id)
        {
            var user = await _userRepository.GetUserByIdAsync(id);
            if(user == null)
            {
                throw new Exception("'Usuário não encontrado.");
            }

            return new UserResponseDto()
            {
               IsSucess = true,
               Data = user
            };
        }

        public async Task<UserResponseDto> UpdateAsync(Guid id, UserRequestDto request)
        {
            var validationResult = await _userValidator.ValidateDefault(request);
            if(!validationResult.IsSucess)
            {
                return new UserResponseDto()
                {
                    IsSucess = false,
                    Errors = validationResult.Errors
                };
            }

           var findUser = await _userRepository.GetUserByIdAsync(id);

            if(findUser == null)
            {
                throw new Exception("Usuário não encontrado.");
            }

          
            findUser.Name = request.Name;
            findUser.Email = request.Email;

            await _userRepository.UpdateUserAsync(findUser);

            return new UserResponseDto()
            {
                IsSucess = true,
                Data = findUser
             };
        }
    }
}
