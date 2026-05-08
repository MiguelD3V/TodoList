using Microsoft.AspNetCore.Mvc.TagHelpers.Cache;
using Microsoft.EntityFrameworkCore;
using System.Collections.Immutable;
using TodoList.API.Data.Interfaces;
using TodoList.API.Models.Entities;

namespace TodoList.API.Data.Repositories
{
    public class TaskRepository : ITaskRepository
    {
        private readonly AppDbContext _context;

        public TaskRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<TaskItem> CreateTaskAsync(TaskItem task)
        {
            _context.Tasks.Add(task);
            await _context.SaveChangesAsync();
            return task;
        }

        public async Task<TaskItem> DeleteTaskAsync(TaskItem task)
        {
            _context.Tasks.Remove(task);
            await _context.SaveChangesAsync();
            return task;
        }

        public async Task<IImmutableList<TaskItem>> GetAllTasksAsync()
        {
            var taskList = await _context.Tasks.ToListAsync();
            return taskList.ToImmutableList();
        }

        public async Task<TaskItem> GetTaskByIdAsync(Guid id)
        {
            var taskFind = await _context.Tasks.FirstOrDefaultAsync(t => t.Id == id);
            return taskFind ?? throw new Exception("Tarefa não encontrada");
        }

        public async Task<TaskItem> UpdateTaskAsync(TaskItem task)
        {
            _context.Tasks.Update(task);
            await _context.SaveChangesAsync();
            return task;
            
        }
    }
}
