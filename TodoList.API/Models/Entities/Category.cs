
using System.Text.Json.Serialization;

namespace TodoList.API.Models.Entities
{
    public record Category
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
    }
}
