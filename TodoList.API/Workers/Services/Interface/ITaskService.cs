using System.Collections.Immutable;
using TodoList.API.Models.Dtos.Task;

namespace TodoList.API.Workers.Services.Interface
{
    public interface ITaskService
    {
        public Task<TaskItemsResponseDto> CreateAsync (TaskItemsRequestDto request);
        public Task<TaskItemsResponseDto> UpdateAsync (Guid id, TaskItemsRequestDto request);
        public Task<TaskItemsResponseDto> DeleteAsync (Guid id);
        public Task<ImmutableList<TaskItemsResponseDto>> GetAllAsync();
        public Task<TaskItemsResponseDto> GetByIdAsync(Guid id);
        public Task<TaskItemsResponseDto> CompleteTaskAsync(Guid id);
    }
}
