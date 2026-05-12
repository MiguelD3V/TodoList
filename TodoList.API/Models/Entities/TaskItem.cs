using TodoList.API.Models.Enums;

namespace TodoList.API.Models.Entities
{
    public record TaskItem
    {
        public Guid Id { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public Priority Priority { get; set; }
        public Status Status { get; set; }
        public DateTime DueDate { get; set; }
        public DateTime CreatedAt { get; set; }
        public Guid UserId { get; set; }
        public Guid CategoryId { get; set; }

    }
}
