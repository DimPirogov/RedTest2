using API.Models;

namespace API.DTO
{
    public class UpdateBookDTO
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Author { get; set; }
    }
}
