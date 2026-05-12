using System.Text.Json.Serialization;
using TodoList.API.Models.Enums;

namespace TodoList.API.Models.Dtos.Task
{
    public class TaskItemsResponseDto : ResponseBase
    {
        [JsonIgnore]
        public Guid Id { get; set; }
        [JsonIgnore]
        public string? Title { get; set; }
        [JsonIgnore]
        public string? Description { get; set; }
        [JsonIgnore]
        public Priority Priority { get; set; }
        [JsonIgnore]
        public Status Status { get; set; }
        [JsonIgnore]
        public DateTime DueDate { get; set; }
        [JsonIgnore]
        public DateTime CreatedAt { get; set; }
        [JsonIgnore]
        public Guid UserId { get; set; }
        [JsonIgnore]
        public Guid CategoryId { get; set; }
    }
}
