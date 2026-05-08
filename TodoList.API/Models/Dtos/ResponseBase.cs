namespace TodoList.API.Models.Dtos
{
    public class ResponseBase
    {
     
        public bool IsSucess { get; set; }
        public object? Data { get; set; }       

        public List<string>? Errors { get; set; } = [];


    }
}