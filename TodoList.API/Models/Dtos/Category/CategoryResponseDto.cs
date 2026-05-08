namespace TodoList.API.Models.Dtos.Category
{
    public class CategoryResponseDto : ResponseBase
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
    }
}
