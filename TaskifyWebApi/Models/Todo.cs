namespace TaskifyWebApi.Models
{
    public class Todo
    {
        public int id { get; set; }
        public required string title { get; set; }
        public required string description { get; set; }
        public bool iscomplete { get; set; }
    }
}
