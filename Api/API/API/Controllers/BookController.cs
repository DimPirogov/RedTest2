using API.Data;
using API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly AppDbContext context;

        public BookController(AppDbContext context)
        {
            this.context = context;
        }
        [HttpGet("GetAllBooks")]
        public async Task<ActionResult<List<Book>>> GetAllBooks()
        {
            List<Book> list = await context.Books!.ToListAsync();
            if (list == null)
            {
                return NotFound();
            }
            return Ok(list);
        }
        [HttpGet("GetBook/{id}")]
        public async Task<ActionResult<Book>> GetBook(int id)
        {
            var book = await context.Books!.Where(e => e.Id == id).SingleOrDefaultAsync();
            if (book != null)
            {
                return Ok(book);
            }
            return NotFound();
        }
        [HttpPost("AddBook")]
        public async Task<ActionResult> AddBook(Book book)
        {
            await context.Books!.AddAsync(book);
            await context.SaveChangesAsync();
            return Ok($"Saved book {book.Title}.");
        }
        [HttpDelete("DeleteBook/{id}")]
        public async Task<ActionResult> DeleteBook(int id)
        {
            var book = await context.Books!.Where(e => e.Id == id).SingleOrDefaultAsync();
            if (book is null)
            {
                return NotFound($"Could not find Book with id {id}");
            }
            context.Books!.Remove(book);
            await context.SaveChangesAsync();
            return Ok($"Deleted Book with id {id}.");
        }
        [HttpPut("UpdateBook/{id}")]
        public async Task<ActionResult<Book>> UpdateBook(int id, Book book)
        {
            if (id != book.Id)
                return BadRequest("Book id mismatch");
            var bookToUpdate = await context.Books!.Where(e => e.Id == id).SingleOrDefaultAsync();
            if (bookToUpdate is null)
                return NotFound($"Book with id {id} not found.");
            bookToUpdate.Author = book.Author;
            bookToUpdate.Title = book.Title;
            if (bookToUpdate.Quotes != null)
                bookToUpdate.Quotes = book.Quotes;
            bookToUpdate.Date = book.Date;
            //await context.UpdateAsync
            await context.SaveChangesAsync();
            return Ok($"Updated Book with id {id}.");
        }
    }
}
