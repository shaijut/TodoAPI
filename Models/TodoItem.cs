namespace TodoAPI.Models
{
    public class TodoItem
    {
        public Int64 Id { get; set; }
        public string? Title { get; set; }
        public bool IsCompleted { get; set; }
    }
}
