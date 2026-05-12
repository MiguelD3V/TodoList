
using System.Text.Json.Serialization;

namespace TodoList.API.Models.Entities
{
    public class Category
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
    }
}
