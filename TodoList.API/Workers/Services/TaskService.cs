using System.Collections.Immutable;
using TodoList.API.Data.Interfaces;
using TodoList.API.Models.Dtos.Task;
using TodoList.API.Workers.Services.Interface;
using TodoList.API.Workers.Validators.Interfaces;

namespace TodoList.API.Workers.Services
{
    public class TaskService : ITaskService
    {
        private readonly ITaskRepository _taskRepository;
        private readonly ITaskValidator _taskValidator;

        public TaskService(ITaskRepository taskRepository, ITaskValidator taskValidator)
        {
            _taskRepository = taskRepository;
            _taskValidator = taskValidator;
        }

        public Task<TaskItemsResponseDto> CreateAsync(TaskItemsRequestDto request)
        {
            throw new NotImplementedException();
        }

        public Task<TaskItemsResponseDto> DeleteAsyn(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<ImmutableList<TaskItemsResponseDto>> GetAllAsync(TaskItemsRequestDto request)
        {
            throw new NotImplementedException();
        }

        public Task<TaskItemsResponseDto> GetByIdAsync(TaskItemsRequestDto request)
        {
            throw new NotImplementedException();
        }

        public Task<TaskItemsResponseDto> UpdateAsync(TaskItemsRequestDto request)
        {
            throw new NotImplementedException();
        }
    }
}
