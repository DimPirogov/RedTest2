﻿namespace API.Models
{
    public class Book
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string? Title { get; set; }
        public string? Author { get; set; }
        public ICollection<Quote>? Quotes { get; set; } 
    }
}
