using TodoList.API.Models.Dtos.Task;
using TodoList.API.Models.Entities;

namespace TodoList.API.Workers.Validators.Interfaces
{
    public interface ITaskValidator
    {
        public Task<TaskItemsResponseDto> ValidadeToCreate(TaskItemsRequestDto request);
        public Task<TaskItemsResponseDto> ValidadeToDelete(TaskItemsRequestDto request);
        public Task<TaskItemsResponseDto> ValidateToUpdate(TaskItemsRequestDto request);

    }
}
