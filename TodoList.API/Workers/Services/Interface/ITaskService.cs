using System.Collections.Immutable;
using TodoList.API.Models.Dtos.Task;

namespace TodoList.API.Workers.Services.Interface
{
    public interface ITaskService
    {
        public Task<TaskItemsResponseDto> CreateAsync (TaskItemsRequestDto request);
        public Task<TaskItemsResponseDto> UpdateAsync (TaskItemsRequestDto request);
        public Task<TaskItemsResponseDto> DeleteAsyn (Guid id);
        public Task<ImmutableList<TaskItemsResponseDto>> GetAllAsync(TaskItemsRequestDto request);
        public Task<TaskItemsResponseDto> GetByIdAsync(TaskItemsRequestDto request);
    }
}
