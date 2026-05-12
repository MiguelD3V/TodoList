using System.ComponentModel.DataAnnotations;

namespace TodoList.API.Models.Entities
{
    public record User
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }

    }
}
