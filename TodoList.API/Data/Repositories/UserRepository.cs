using Microsoft.EntityFrameworkCore;
using System.Collections.Immutable;
using TodoList.API.Data.Interfaces;
using TodoList.API.Models.Entities;

namespace TodoList.API.Data.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _context;

        public UserRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<User> CreateUserAsync(User user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return user;
        }

        public async Task<User> DeleteUserAsync(User user)
        {
            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
            return user;
        }

        public async Task<IImmutableList<User>> GetAllUsersAsync()
        {
            var users = await _context.Users.ToListAsync();
            return users.ToImmutableList();
        }

        public async Task<User> GetUserByIdAsync(Guid id)
        {
            var user = await _context.Users.FirstOrDefaultAsync(x => x.Id == id);
            return user ?? throw new Exception("Não foi possivel encrontrar o Usuario");
        }

        public async Task<User> UpdateUserAsync(User user)
        {
            _context.Users.Update(user);
            await _context.SaveChangesAsync();
            return user;
        }
    }
}
