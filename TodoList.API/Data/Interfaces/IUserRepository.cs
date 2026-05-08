using System.Collections.Immutable;
using TodoList.API.Models.Entities;

namespace TodoList.API.Data.Interfaces
{
    public interface IUserRepository
    {
        public Task<User> CreateUserAsync(User user);
        public Task<User> UpdateUserAsync(User user);
        public Task<User> DeleteUserAsync(User user);
        public Task<IImmutableList<User>> GetAllUsersAsync();
        public Task<User> GetUserByIdAsync(Guid id);
    }
}
