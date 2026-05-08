using System.Collections.Immutable;
using TodoList.API.Models.Entities;

namespace TodoList.API.Data.Interfaces
{
    public interface ITaskRepository
    {
        public Task<TaskItem> CreateTaskAsync(TaskItem task);
        public Task<TaskItem> UpdateTaskAsync(TaskItem task);
        public Task<TaskItem> DeleteTaskAsync(TaskItem task);
        public Task<IImmutableList<TaskItem>> GetAllTasksAsync();
        public Task<TaskItem> GetTaskByIdAsync(Guid id);
    }
}
