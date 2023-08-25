using API.Data;
using API.DTO;
using API.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net;

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
            List<Book> list = await context.Books!.Include(B => B.Quotes).ToListAsync();
            if (list == null)
            {
                return NotFound();
            }
            return Ok(list);
        }
        [HttpGet("GetBook/{id}")]
        public async Task<ActionResult<Book>> GetBook(int id)
        {
            var book = await context.Books!.Where(B => B.Id == id).SingleOrDefaultAsync();
            if (book != null)
            {
                return Ok(book);
            }
            return NotFound();
        }
        //[Authorize]
        [HttpPost("AddBook")]
        public async Task<ActionResult<Book>> AddBook(AddBookDTO newBook)
        {
            var book = new Book { Author = newBook.Author, Date = DateTime.Now, Title = newBook.Title };
            await context.Books!.AddAsync(book);
            await context.SaveChangesAsync();
            return Ok(book);
        }
        //[Authorize]
        [HttpDelete("DeleteBook/{id}")]
        public async Task<ActionResult> DeleteBook(int id)
        {
            var book = await context.Books!.Where(B => B.Id == id).SingleOrDefaultAsync();
            if (book is null)
            {
                return NotFound($"Could not find Book with id {id}");
            }
            context.Books!.Remove(book);
            await context.SaveChangesAsync();
            return Ok();
            //return Ok($"Deleted Book with id {id}.");
        }
        //[Authorize]
        [HttpPut("UpdateBook/{id}")]
        public async Task<ActionResult<Book>> UpdateBook( UpdateBookDTO book)
        {
            var bookToUpdate = await context.Books!.Where(B => B.Id == book.Id).SingleOrDefaultAsync();
            if (bookToUpdate is null)
                return NotFound($"Book with id {book.Id} not found.");
            bookToUpdate.Author = book.Author;
            bookToUpdate.Title = book.Title;
            await context.SaveChangesAsync();
            //return Ok($"Updated Book with id {book.Id}.");
            return Ok();
        }
        // quotes section
        [HttpGet("GetBook/{bookId}/quotes")]
        public async Task<ActionResult<List<Quote>>> GetBookQuotes(int bookId)
        {
            List<Quote> list = await context.Quotes!.Where(B => B.BookId == bookId).ToListAsync();
            if (list == null)
            {
                return NotFound($"There are no quotes in this Book.");
            }
            return Ok(list);
        }
        //[Authorize]
        [HttpPost("AddQuotes")]
        public async Task<ActionResult> AddBookQuote(AddQuoteDTO newQuote)
        { 
            var quote = new Quote { BookId = newQuote.BookId, Text = newQuote.Text };
            await context.Quotes!.AddAsync(quote);
            await context.SaveChangesAsync();
            return Ok(quote);
            //return Ok($"Saved quote \"{QuoteToAdd.Text}\".");
        }
        //[Authorize]
        [HttpDelete("DeleteQuote/{quoteId}")]
        public async Task<ActionResult> DeleteBookQuote(int quoteId)
        {
            var quote = await context.Quotes!.Where(Q => Q.Id == quoteId).SingleOrDefaultAsync();
            if (quote is null)
            {
                return NotFound($"Could not find Quote with id {quoteId}");
            }
            context.Quotes!.Remove(quote);
            await context.SaveChangesAsync();
            return Ok();
            //return Ok($"Deleted Quote \" {quote.Text} \".");
        }
    }
}
