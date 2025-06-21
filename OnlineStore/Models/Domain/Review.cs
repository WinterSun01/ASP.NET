namespace OnlineStore.Models.Domain
{
    public class Review
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public string? Author { get; set; }
        public string? Content { get; set; }
    }
}
