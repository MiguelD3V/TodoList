using Microsoft.AspNetCore.Mvc;
using TodoList.API.Models.Dtos.Task;
using TodoList.API.Workers.Services.Interface;

namespace TodoList.API.Controllers
{
    [ApiController]
    [Route("TodoList.API/[controller]")]
    public class TaskController : Controller
    {
        private readonly ITaskService _taskService;

        public TaskController(ITaskService taskService)
        {
            _taskService = taskService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateTaskAsync([FromBody] TaskItemsRequestDto request)
        {
            try
            {
                var result = await _taskService.CreateAsync(request);
                return Ok(result);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetAllTasksAsync()
        {
            try
            {
                var result = await _taskService.GetAllAsync();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTaskByIdAsync(Guid id)
        {
            try
            {
                var result = await _taskService.GetByIdAsync(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTaskAsync(Guid id)
        {
            try
            {
                var result = await _taskService.DeleteAsync(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTaskAsync(Guid id, [FromBody] TaskItemsRequestDto request)
        {
            try
            {
                var result = await _taskService.UpdateAsync(id, request);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPatch("{id}/complete")]
        public async Task<IActionResult> CompleteTaskAsync(Guid id)
        {
            try
            {
                var result = await _taskService.CompleteTaskAsync(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
