using library.Server.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace library.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BookController : ControllerBase
    {
        private readonly ILogger<BookController> _logger;
        private readonly AppDbContext _appDbContext;

        public BookController(ILogger<BookController> logger, AppDbContext appDbContext)
        {
            _logger = logger;
            _appDbContext = appDbContext;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Book>>> GetBooks()
        {
            try
            {
                var books = await _appDbContext.Books
                        .Where(b => !b.IsDeleted)
                        .ToListAsync();
                return Ok(books); 
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while retrieving books.");
                return StatusCode(500, "Internal server error"); 
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Book>> GetBookById(int id)
        {
            try
            {
                var book = await _appDbContext.Books.FindAsync(id);

                if (book == null)
                {
                    return NotFound();
                }

                return Ok(book); 
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while retrieving the book.");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpDelete("SoftDeleteBook"+ "/" +"{id}")]
        public async Task<ActionResult<Book>> SoftDeleteBook(int id)
        {
            {
                try
                {
                    var book = await _appDbContext.Books.FindAsync(id);

                    if (book == null)
                    {
                        return NotFound();
                    }

                    book.IsDeleted = true;

                    _appDbContext.Books.Update(book);
                    await _appDbContext.SaveChangesAsync();

                    return NoContent();
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "An error occurred while soft deleting the book.");
                    return StatusCode(500, "Internal server error");
                }
            }
        }

        [HttpPost("NewBook")]
        public async Task<ActionResult<Book>> CreateBook([FromBody] Book book)
        {
            try
            {
                _appDbContext.Books.Add(book);
                await _appDbContext.SaveChangesAsync();

                return CreatedAtRoute("GetBookById", new { id = book.Id }, book);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while creating the book.");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPut("Edit")]
        public async Task<ActionResult> EditBook(int id, [FromBody] Book updatedBook)
        {
            try
            {
                var book = await _appDbContext.Books.FindAsync(id);

                if (book == null)
                {
                    return NotFound();
                }

                book.Title = updatedBook.Title;
                book.Author = updatedBook.Author;
                book.Description = updatedBook.Description;
                book.IsDeleted = updatedBook.IsDeleted;
                book.Publisher = updatedBook.Publisher;
                book.PageCount = updatedBook.PageCount;
                book.ISBN = updatedBook.ISBN;
                book.Category = updatedBook.Category;

                _appDbContext.Books.Update(book);
                await _appDbContext.SaveChangesAsync();

                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while updating the book.");
                return StatusCode(500, "Internal server error");
            }
        }
    }
}
