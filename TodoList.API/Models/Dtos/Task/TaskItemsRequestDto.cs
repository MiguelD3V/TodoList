using TodoList.API.Models.Enums;

namespace TodoList.API.Models.Dtos.Task
{
    public record TaskItemsRequestDto
    {
        public string? Title { get; set; }
        public string? Description { get; set; }
        public Priority Priority { get; set; }
        public DateTime DueDate { get; set; }
        public Guid UserId { get; set; }
        public Guid CategoryId { get; set; }
    }
}
