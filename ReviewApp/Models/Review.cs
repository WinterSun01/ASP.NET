namespace ReviewApp.Models
{
    public class Review
    {
        public string Author { get; set; } = string.Empty;
        public string Message { get; set; } = string.Empty;
        public int Rating { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}
