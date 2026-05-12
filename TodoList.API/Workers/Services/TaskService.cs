using System.Collections.Immutable;
using TodoList.API.Data.Interfaces;
using TodoList.API.Models.Dtos.Task;
using TodoList.API.Models.Entities;
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

        public async Task<TaskItemsResponseDto> CompleteTaskAsync(Guid id)
        {
            var findTask = await _taskRepository.GetTaskByIdAsync(id);

            findTask.Status = Models.Enums.Status.Done;

            await _taskRepository.UpdateTaskAsync(findTask);
            return new TaskItemsResponseDto
            {
                IsSucess = true,
                Data = findTask
            };
        }

        public async Task<TaskItemsResponseDto> CreateAsync(TaskItemsRequestDto request)
        {
            var validationResult = await _taskValidator.ValidadeToCreate(request);
            if (!validationResult.IsSucess)
            {
                return new TaskItemsResponseDto
                {
                    IsSucess = false,
                    Errors = validationResult.Errors
                };
            }

            TaskItem entity = new TaskItem()
            {
                Title = request.Title,
                Description = request.Description,
                Priority = request.Priority,
                DueDate = request.DueDate,
                UserId = request.UserId,
                CategoryId = request.CategoryId,
                CreatedAt = DateTime.UtcNow
            };

            await _taskRepository.CreateTaskAsync(entity);
            return new TaskItemsResponseDto
            {
                IsSucess = true,
                Data = entity
            };
        }

        public async Task<TaskItemsResponseDto> DeleteAsync(Guid id)
        {
            var findTask = await _taskRepository.GetTaskByIdAsync(id);
            if (findTask == null)
            {
                throw new Exception("Tarefa não encontrada");
            }

            await _taskRepository.DeleteTaskAsync(findTask);

            return new TaskItemsResponseDto
            {
                IsSucess = true,
                Data = findTask
            };
        }

        public async Task<ImmutableList<TaskItemsResponseDto>> GetAllAsync()
        {
            var tasks = await _taskRepository.GetAllTasksAsync();

            return tasks
                .Select(task => new TaskItemsResponseDto
            {
                IsSucess = true,
                Data = task
            }).ToImmutableList();
        }

        public async Task<TaskItemsResponseDto> GetByIdAsync(Guid id)
        {
            var findTask = await _taskRepository.GetTaskByIdAsync(id);
            if (findTask == null)
            {
                throw new Exception("Tarefa não encontrada");
            }

            return new TaskItemsResponseDto
            {
                IsSucess = true,
                Data = findTask
            };
        }

        public async Task<TaskItemsResponseDto> UpdateAsync(Guid id, TaskItemsRequestDto request)
        {
            var validationResult = await _taskValidator.ValidateToUpdate(request);
            if (!validationResult.IsSucess)
            {
                return new TaskItemsResponseDto
                {
                    IsSucess = false,
                    Errors = validationResult.Errors
                };
            }

            var findTask = await _taskRepository.GetTaskByIdAsync(id);
            if (findTask == null)
            {
                throw new Exception("Tarefa não encontrada");
            }
            
            findTask.Title = request.Title;
            findTask.Description = request.Description;
            findTask.Priority = request.Priority;
            findTask.DueDate = request.DueDate;
            findTask.UserId = request.UserId;
            findTask.CategoryId = request.CategoryId;
            findTask.DueDate = request.DueDate;

            await _taskRepository.UpdateTaskAsync(findTask);

            return new TaskItemsResponseDto
            {
                IsSucess = true,
                Data = findTask
            };


        }
    }
}
