using TodoList.API.Models.Dtos.Task;
using TodoList.API.Models.Entities;
using TodoList.API.Workers.Validators.Interfaces;

namespace TodoList.API.Workers.Validators
{
    public class TaskValidator : ITaskValidator
    {
        public async Task<TaskItemsResponseDto> ValidadeToCreate(TaskItemsRequestDto request)
        {
            var response = new TaskItemsResponseDto()
            {
                Errors = []
            };

            if (string.IsNullOrWhiteSpace(request.Title))
            {
                response.IsSucess = false;
                response.Errors.Add("O Nome da tarefa não pode ser nulo.");
            }
            if (request.Priority == 0)
            {
                response.IsSucess = false;
                response.Errors.Add("A Prioridade da tarefa deve ser informada.");
            }
            if (response.UserId == Guid.Empty)
            {
                response.IsSucess = false;
                response.Errors.Add("O Id do usuário deve ser informado.");
            }
            if (response.CategoryId == Guid.Empty)
            {
                response.IsSucess = false;
                response.Errors.Add("O Id da categoria deve ser informado.");
            }
            if (response.DueDate < DateTime.UtcNow)
            {
                response.IsSucess = false;
                response.Errors.Add("A data de vencimento deve ser maior que a data atual.");
            }
            if (response.Errors.Count == 0)
            {
                response.IsSucess = true;
                response.Data = request;
            }
            return response;

        }
       

        public Task<TaskItemsResponseDto> ValidadeToDelete(TaskItemsRequestDto request)
        {
            throw new NotImplementedException();
        }

        public async Task<TaskItemsResponseDto> ValidateToUpdate(TaskItemsRequestDto request)
        {
            var response = new TaskItemsResponseDto()
            {
                Errors = []
            };

            if (string.IsNullOrWhiteSpace(request.Title))
            {
                response.IsSucess = false;
                response.Errors.Add("O Nome da tarefa não pode ser nulo.");
            }
            if (request.Priority == 0)
            {
                response.IsSucess = false;
                response.Errors.Add("A Prioridade da tarefa deve ser informada.");
            }
            if (response.UserId == Guid.Empty)
            {
                response.IsSucess = false;
                response.Errors.Add("O Id do usuário deve ser informado.");
            }
            if (response.CategoryId == Guid.Empty)
            {
                response.IsSucess = false;
                response.Errors.Add("O Id da categoria deve ser informado.");
            }
            if (response.DueDate < DateTime.UtcNow)
            {
                response.IsSucess = false;
                response.Errors.Add("A data de vencimento deve ser maior que a data atual.");
            }
            if (response.Errors.Count == 0)
            {
                response.IsSucess = true;
                response.Data = request;
            }
            return response;
        }
    }
}
