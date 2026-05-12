namespace TodoList.API.Models.Dtos.User
{
    public record UserRequestDto
    {
        public string? Name { get; set; }
        public string? Email { get; set; }
    }
}
