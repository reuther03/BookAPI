using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BookAPI;

[ApiController]
[Route("[controller]")]
public class BooksController : ControllerBase
{
    private readonly BookDbContext _context;

    public BooksController(BookDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public IActionResult GetAllBooks()
    {
        var result = _context.Books
            .Include(b => b.BookAuthors)
            .ToList();

        return Ok(result);
    }
}
