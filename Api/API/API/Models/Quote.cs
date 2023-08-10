namespace API.Models
{
    public class Quote
    {
        public int Id { get; set; }
        public string Text { get; set; } = string.Empty;
        public int BookId { get; set; }
        public Book? Book { get; set; }
    }
}
