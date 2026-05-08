namespace TodoList.API.Models.Dtos.User
{
    public class UserResponseDto : ResponseBase
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
    }
}
