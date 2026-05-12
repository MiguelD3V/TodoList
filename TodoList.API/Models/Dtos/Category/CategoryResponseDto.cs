using System.Text.Json.Serialization;

namespace TodoList.API.Models.Dtos.Category
{
    public class CategoryResponseDto : ResponseBase
    {
        [JsonIgnore]
        public Guid Id { get; set; }
        [JsonIgnore]
        public string? Name { get; set; }
    }
}
