using API.Models;
using Microsoft.EntityFrameworkCore;

namespace API.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<Book>? Books { get; set; }
        public DbSet<Quote>? Quotes { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Book>().HasData(
                new Book
                {
                    Id = 10,
                    Date = new DateTime(1800, 02, 15),
                    Title = "Wars",
                    Author = "Uknown",
                });
            modelBuilder.Entity<Book>().HasData(
                new Book
                {
                    Id = 11,
                    Date = new DateTime(1700, 02, 15),
                    Title = "Peacetimes",
                    Author = "Mankind",
                });
            modelBuilder.Entity<Book>().HasData(
                new Book
                {
                    Id = 12,
                    Date = new DateTime(1968, 01, 01),
                    Title = "2001: A Space Odyssey",
                    Author = "Arthur C. Clarke",
                });
            modelBuilder.Entity<Book>().HasData(
                new Book
                {
                    Id = 13,
                    Date = new DateTime(2014, 02, 15),
                    Title = "Book nr 4",
                    Author = "Uknown",
                });
        }
    }
}
