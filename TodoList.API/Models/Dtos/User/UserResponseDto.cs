using System.Text.Json.Serialization;

namespace TodoList.API.Models.Dtos.User
{
    public class UserResponseDto : ResponseBase
    {
        [JsonIgnore]
        public Guid Id { get; set; }
        [JsonIgnore]
        public string? Name { get; set; }
        [JsonIgnore]
        public string? Email { get; set; }
    }
}
